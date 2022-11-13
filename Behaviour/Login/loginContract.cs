// using System;
// using System.IO;
// using System.Security.Cryptography;
// using System.Text;
// using System.Linq;
// using AmritERP.Model;
// using System.Collections.Generic;

// namespace AmritERP.Behaviour.Login
// {

//     public class userRollsObj
//     {
//         public TblUserRolls userRolls { get; set; }
//         public List<TblUserRollsPages> userRollsPages { get; set; }
//     }

//     public class loginCheckOBJ
//     {
//         public string loginName { get; set; }
//         public string password { get; set; }
//     }
//     public class loginContract
//     {
//         public int flag = 0;
//         public string Message = string.Empty;

//         private string Encrypt(string clearText)
//         {
//             string EncryptionKey = "JAIBALAJI108";
//             byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
//             using (Aes encryptor = Aes.Create())
//             {
//                 Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
//                 encryptor.Key = pdb.GetBytes(32);
//                 encryptor.IV = pdb.GetBytes(16);
//                 using (MemoryStream ms = new MemoryStream())
//                 {
//                     using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
//                     {
//                         cs.Write(clearBytes, 0, clearBytes.Length);
//                         cs.Close();
//                     }
//                     clearText = Convert.ToBase64String(ms.ToArray());
//                 }
//             }
//             return clearText;
//         }

//         public object getLoginType()
//         {
//             using (var db = new TallyDBContext())
//             {
//                 return db.TblLoginType.Select(x => new
//                 {
//                     x.LoginTypeId,
//                     x.LoginTypeName
//                 }).ToList();
//             }
//         }
//         public object updateLoginType(TblLoginType tblLoginType)
//         {
//             using (var db = new TallyDBContext())
//             {
//                 TblLoginType check = db.TblLoginType.Where(x => x.LoginTypeId == tblLoginType.LoginTypeId).FirstOrDefault();
//                 if (check == null)
//                 {
//                     db.TblLoginType.Add(tblLoginType);
//                     flag = db.SaveChanges();
//                     if (flag == 1)
//                         Message = "Login Type Added Successfully";
//                     else
//                         Message = "Error in adding login type";
//                 }
//                 else
//                 {
//                     check.LoginTypeName = tblLoginType.LoginTypeName;
//                     db.SaveChanges();
//                     flag = 1;
//                     Message = "Login Type Updated Successfully";
//                 }
//             }
//             object[] output = { flag, Message };
//             return output;
//         }

//         public object updateLogin(TblLogin login)
//         {
//             using (var db = new TallyDBContext())
//             {
//                 TblLogin checkLogin = db.TblLogin.Where(x => x.LoginId == login.LoginId).FirstOrDefault();
//                 if (checkLogin == null)
//                 {
//                     login.LoginName = Encrypt(login.LoginName);
//                     login.LoginPassword = Encrypt(login.LoginPassword);
//                     db.TblLogin.Add(login);
//                     flag = db.SaveChanges();
//                     if (flag == 1)
//                         Message = "Login Created Successfully";
//                     else
//                         Message = "Error in Creating Login";
//                 }
//                 else
//                 {
//                     checkLogin.IsDeleted = login.IsDeleted;
//                     checkLogin.LoginName = Encrypt(login.LoginName);
//                     checkLogin.LoginPassword = Encrypt(login.LoginPassword);
//                     checkLogin.LoginTypeId = login.LoginTypeId;
//                     db.SaveChanges();
//                     flag = 1;
//                     Message = "Login Data Updated Successfully";
//                 }

//             }
//             object[] output = { flag, Message };
//             return output;
//         }

//         public object checkLogin(loginCheckOBJ loginCheck)
//         {
//             using (var db = new TallyDBContext())
//             {
//                 TblLogin check = db.TblLogin.Where(x => x.IsDeleted == false && x.LoginName == Encrypt(loginCheck.loginName) && x.LoginPassword == Encrypt(loginCheck.password)).FirstOrDefault();
//                 if (check != null)
//                 {
//                     List<int> menuIds = new List<int>();
//                     List<int> pageIds = new List<int>();
//                     if (check.LoginTypeId == 1) // Admin
//                     {
//                         menuIds = db.TblMenu.Where(x => x.IsDeleted == false).Select(x => x.MenuId).ToList();
//                         pageIds = db.TblPages.Where(x => x.IsDeleted == false).Select(x => x.PageId).ToList();
//                     }
//                     else
//                     {
//                         pageIds = db.TblUserRollsPages.Where(x => x.UserRoll.LoginTypeId == check.LoginTypeId).Select(x => x.PageId).Distinct().ToList();
//                         menuIds = db.TblPages.Where(x => pageIds.Contains(x.PageId)).Select(x => x.MenuId).Distinct().ToList();
//                     }
//                     var allowedPages = db.TblMenu.Where(x => menuIds.Contains(x.MenuId) && x.IsDeleted == false).Select(x => new
//                     {
//                         loginTypeID = check.LoginTypeId,
//                         loginID = check.LoginId,
//                         x.MenuId,
//                         x.MenuName,
//                         x.MenuOrder,
//                         pageList = x.TblPages.Where(w => pageIds.Contains(w.PageId) && w.IsDeleted == false && w.ShowInMenu == true).Select(w => new
//                         {
//                             w.PageId,
//                             w.PageName,
//                             w.PageUri,
//                             w.PageOrder
//                         }).OrderBy(w=>w.PageOrder).ToList()
//                     }).ToList();
//                     flag = 1;
//                     Message = "Login Successfull";
//                     object[] output = { flag, Message, allowedPages };
//                     return output;
//                 }
//                 else
//                 {
//                     flag = 0;
//                     Message = "Login ID or Password Not Correct";
//                     object[] output = { flag, Message };
//                     return output;
//                 }
//             }

//         }

//         public object updateUserRolls(userRollsObj userRolls)
//         {
//             using (var db = new TallyDBContext())
//             {
//                 using (var transaction = db.Database.BeginTransaction())
//                 {
//                     TblUserRolls check = db.TblUserRolls.Where(x => x.LoginTypeId == userRolls.userRolls.LoginTypeId).FirstOrDefault();
//                     if (check == null)
//                     {
//                         db.TblUserRolls.Add(userRolls.userRolls);
//                         flag = db.SaveChanges();
//                         if (flag == 1)
//                         {
//                             userRolls.userRollsPages.ForEach(x => x.UserRollId = userRolls.userRolls.UserRollId);
//                             db.TblUserRollsPages.AddRange(userRolls.userRollsPages);
//                             flag = db.SaveChanges();
//                             if (flag == userRolls.userRollsPages.Count())
//                             {
//                                 transaction.Commit();
//                                 flag = 1;
//                                 Message = "User Rolls Added Successfully";
//                             }
//                             else
//                             {
//                                 transaction.Dispose();
//                                 Message = "Error in adding User Pages";
//                                 flag = 0;
//                             }
//                         }
//                         else
//                         {
//                             transaction.Dispose();
//                             flag = 0;
//                             Message = "Error in creating User Rolls";
//                         }
//                     }
//                     else
//                     {
//                         List<TblUserRollsPages> deleteAll = db.TblUserRollsPages.Where(x => x.UserRollId == check.UserRollId).ToList();
//                         db.TblUserRollsPages.RemoveRange(deleteAll);
//                         flag = db.SaveChanges();
//                         if (flag == deleteAll.Count())
//                         {
//                             userRolls.userRollsPages.ForEach(x => x.UserRollId = check.UserRollId);
//                             db.TblUserRollsPages.AddRange(userRolls.userRollsPages);
//                             flag = db.SaveChanges();
//                             if (flag == userRolls.userRollsPages.Count())
//                             {
//                                 transaction.Commit();
//                                 flag = 1;
//                                 Message = "User Rolls Added Successfully";
//                             }
//                             else
//                             {
//                                 transaction.Dispose();
//                                 Message = "Error in adding User Pages";
//                                 flag = 0;
//                             }
//                         }
//                         else
//                         {
//                             transaction.Dispose();
//                             Message = "Error in Updating user Rolls Pages";
//                             flag = 0;
//                         }
//                     }
//                 }
//             }
//             object[] output = { flag, Message };
//             return output;
//         }
//     }
// }
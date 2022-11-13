namespace AmritERP.Behaviour.Error
{
    public class ErrorExtension
    {
        public void errorLogger (string errorMsg, string innerMessage, string Stacktrace, string Source) {
            // using (var db = new RDMDBContext ()) {
            //     DateTime currentDT = DateTime.UtcNow.AddMinutes (330);
            //     TblError error = new TblError ();
            //     error.ErrorMessage = Stacktrace;
            //     error.ErrorDatetime = currentDT;
            //     db.TblError.Add (error);
            //     db.SaveChanges ();

            // }
        }
    }
}
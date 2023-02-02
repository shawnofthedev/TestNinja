namespace TestNinja.Lib
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            //do the logging stuff
            var errorId = Guid.NewGuid();
            OnErrorLogged(errorId);
        }

        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged.Invoke(this, errorId);
        }
    }
}

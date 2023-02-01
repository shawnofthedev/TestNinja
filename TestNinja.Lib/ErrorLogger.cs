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

            OnErrorLogged(Guid.NewGuid());
        }

        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged.Invoke(this, errorId);
        }
    }
}

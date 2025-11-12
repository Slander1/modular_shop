namespace Core.Utility
{
    public class SingletonBase<T> where T : SingletonBase<T>, new()
    {
        private static T _instance = new T();
        
        public static T Instance
        {
            get
            {    
                if (_instance == null) _instance = new T();
                return _instance;
            }   
        }
    }

}
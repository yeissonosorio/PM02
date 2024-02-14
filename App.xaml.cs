﻿namespace PM02
{
    public partial class App : Application
    {
        static Controllers.PersonasControllers database;

        // Create the database connection as a singleton.
        public static Controllers.PersonasControllers Database
        {
            get
            {
                if (database == null)
                {
                    database = new Controllers.PersonasControllers();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            
            MainPage = new NavigationPage(new PageListPersonas());
        }
    }
}

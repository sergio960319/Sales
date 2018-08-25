namespace Sales.Infraestructure
{
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Sales.ViewModels;


    public class InstanceLocator
    {
        public MainViewModel Main
        { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}

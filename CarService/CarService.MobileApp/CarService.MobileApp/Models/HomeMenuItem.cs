using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.MobileApp.Models
{
    public enum MenuItemType
    {
       Home,
        Profil,
        Odjava
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

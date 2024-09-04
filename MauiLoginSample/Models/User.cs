﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiLoginSample.Helpers;

namespace MauiLoginSample.Models
{
    public partial class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ServiceStartDate { get; set; }
    }

    public partial class User
    {
        public static User FromJson(string json) => JsonConvert.DeserializeObject<User>(json, Converter.Settings);
        public static List<User> GetUsersFromJson(string json) => JsonConvert.DeserializeObject<User[]>(json, Converter.Settings).ToList();
        public static string ToJson(User self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

}

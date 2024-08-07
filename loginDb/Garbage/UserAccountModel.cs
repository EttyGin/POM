using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;

namespace loginDb.Models
{
    public class UserAccountModel2
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public ImageSource ProfilePicture { get; set; }
 
    }
}
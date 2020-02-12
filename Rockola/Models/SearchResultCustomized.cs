using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rockola.Models
{
    public class SearchResultCustomized
    {
         string title;
         string imageUrl;
         string videoId;
         string description;    
         string expo;

            
        public string VideoId
        {
            get { return videoId; }
            set { videoId = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Expo
        {
            get { return expo; }
            set { expo = value; }
        }
    }
}
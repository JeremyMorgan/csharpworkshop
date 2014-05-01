using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace GraphicProducts.Models
{
    public abstract class SimplePage
    {
        // private fields. Will be accessed by public fields, but I'm setting this up for future expansion plans.
        private int _PageID;
        private string _PageSlug;
        private string _Title;
        private string _Description;
        private string _Keywords;
        private string _Author;
        private string _GooglePlus;
        private string _Image;
        private string _PublishTime;
        private int _Category;
        private int _SubCategory;
        private string _CategoryName;
        private string _SubCategoryName;
        private string _PageContent;
        private int _PageType;
        private bool _isActive;
 
        public int PageID { set { _PageID = value; } get { return _PageID; }}
        public string PageSlug { set { _PageSlug = value; } get { return _PageSlug; }}
        public string Title { set { _Title  = value; } get { return _Title ; }}
        public string Description { set { _Description  = value; } get { return _Description; }}
        public string Keywords { set { _Keywords = value; } get { return _Keywords; }}
        public string Author { set { _Author = value; } get { return _Author; }}
        public string GooglePlus { set { _GooglePlus = value; } get { return _GooglePlus; }}
        public string Image { set { _Image = value; } get { return _Image; }}
        public string PublishTime { set { _PublishTime = value; } get { return _PublishTime; }}
        public int Category { set { _Category = value; } get { return _Category; }}
        public int SubCategory { set { _SubCategory = value; } get { return _SubCategory; }}
        public string CategoryName { set { _CategoryName = value; } get { return _CategoryName; } }
        public string SubCategoryName { set { _SubCategoryName = value; } get { return _SubCategoryName; } }
        public string PageContent { set { _PageContent = value; } get { return _PageContent; }}
        public int PageType  { set { _PageType = value; } get { return _PageType; }}
        public bool isActive  { set { _isActive = value; } get { return _isActive; }}
       
 
        public SimplePage()
        {
          // build page object
        }
 
    }
}

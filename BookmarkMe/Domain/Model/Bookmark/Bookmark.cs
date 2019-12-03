namespace BookmarkMe.Domain.Model.Bookmark
{
    using System;
    using Shared;

    internal class Bookmark : IEntity, IBookmark
    {
        private readonly int id;

        private string name;
        private string uri;
        private string logoUrl;

        public Bookmark(int id, string name, string uri, string logoUrl)
        {
            this.id = id;

            Name = name;
            Url = uri;
            LogoUrl = logoUrl;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null, empty or whitespace.");
                }

                name = value;
            }
        }

        public string Url
        {
            get
            {
                return uri;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null, empty or whitespace.");
                }

                uri = value;
            }
        }

        public string LogoUrl
        {
            get
            {
                return logoUrl;
            }

            private set
            {
                logoUrl = value;
            }
        }

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void ChangeUrl(string newUrl)
        {
            Url = newUrl;
        }
    }
}

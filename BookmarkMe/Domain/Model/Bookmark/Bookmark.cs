namespace BookmarkMe.Domain.Model.Bookmark
{
    using System;
    using Shared;

    internal class Bookmark : IEntity, IBookmark
    {
        private readonly int id;

        private string name;
        private string uri;

        public Bookmark(int id, string name, string uri)
        {
            this.id = id;

            Name = name;
            Uri = uri;
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

        public string Uri
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

        public void Rename(string newName)
        {
            Name = newName;
        }

        public void ChangeUri(string newUri)
        {
            Uri = newUri;
        }
    }
}

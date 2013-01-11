using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository.ObjectRepositories
{
    /// <summary>
    /// Object-based user post repository
    /// </summary>
    public class ObjectUserPostRepository : IUserPostRepository
    {
        private Collection<UserPostEntity> _userPosts;
        private static long identityIdCounter = 1;

        #region Default constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObjectUserPostRepository()
        {
            _userPosts = new Collection<UserPostEntity>();

            Random rnd = new Random();
            IUserRepository userRepository = Repository.UserRepositoryInstance;

			List<String> images = ObjectUserPostRepository.GetImagesPath();
            List<String> thumbnails = ObjectUserPostRepository.GetThumbnailsPath();

            foreach (UserEntity user in userRepository.GetAll())
            {
                int postCount = rnd.Next(1, 100);
                for (int i = 0; i < postCount; i++)
					_userPosts.Add(new UserPostEntity() { Id = identityIdCounter++, AuthorUserId = user.Id, BoardId = user.Id, Title = string.Format("Имя картинки {0}", rnd.Next(1000)), Message = string.Format("Здесь может быть какое-то сообщение {0}", rnd.Next(1000)), LikesCount = rnd.Next(1000), ImageUrl = images[rnd.Next(6)].ToString(), ThumbnailUrl = thumbnails[rnd.Next(6)].ToString() });
            }
        }

        #endregion

        /// <summary>
        /// Gets all images
        /// </summary>
        /// <returns>all images</returns>
		static List<String> GetImagesPath()
		{
			DirectoryInfo folder = new DirectoryInfo(HttpContext.Current.Server.MapPath("/Images"));
			FileInfo[] images = folder.GetFiles();

			List<String> imagesList = new List<String>();
			for (int i = 0; i < images.Length; i++)
			{
				imagesList.Add(string.Format(@"Images/{0}", images[i].Name));
			}

			return imagesList;
		}

        /// <summary>
        /// Gets all thumbnails
        /// </summary>
        /// <returns>all thumbnails</returns>
        static List<String> GetThumbnailsPath()
        {
            DirectoryInfo folder = new DirectoryInfo(HttpContext.Current.Server.MapPath("/Images/Thumbnails"));
            FileInfo[] images = folder.GetFiles();

            List<String> imagesList = new List<String>();
            for (int i = 0; i < images.Length; i++)
            {
                imagesList.Add(string.Format(@"Images/Thumbnails/{0}", images[i].Name));
            }

            return imagesList;
        }

        /// <summary>
        /// Clear all user posts
        /// </summary>
        public void Dispose()
        {
            _userPosts.Clear();
        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>singlt post or null</returns>
        public UserPostEntity Get(long id)
        {
            return _userPosts.SingleOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Gets all user posts from certain board
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="boardId"></param>
        /// <returns>all user posts from certain board</returns>
        public Collection<UserPostEntity> Get(int userId, int boardId)
        {
            Collection<UserPostEntity> posts = new Collection<UserPostEntity>();

            if (Repository.UserRepositoryInstance.IsExists(userId))
            {
                foreach (UserPostEntity post in _userPosts.Where(r => r.AuthorUserId == userId && r.BoardId == boardId))
                    posts.Add(post);
            }

            return posts;
        }

        /// <summary>
        /// Gets all user posts
        /// </summary>
        /// <returns>all user posts</returns>
        public Collection<UserPostEntity> GetAll()
        {            
            return _userPosts;
        }

        /// <summary>
        /// Check if post exists by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>if exists</returns>
        public bool IsExists(long id)
        {
            return (_userPosts.Count(r => r.Id == id) == 1);
        }

        /// <summary>
        /// Gets count of posts
        /// </summary>
        /// <returns>count of posts</returns>
        public long GetCount()
        {
            return _userPosts.Count;
        }
    }
}

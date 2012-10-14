using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ObjectUserPostRepository()
        {
            _userPosts = new Collection<UserPostEntity>();

            Random rnd = new Random();
            IUserRepository userRepository = Repository.UserRepositoryInstance;

            foreach (UserEntity user in userRepository.GetAll())
            {
                int postCount = rnd.Next(1, 100);
                for (int i = 0; i < postCount; i++)
                    _userPosts.Add(new UserPostEntity() { Id = identityIdCounter++, AuthorUserId = user.Id, BoardId = user.Id, Title = string.Format("Имя картинки {0}", rnd.Next(1000)), Message = string.Format("Здесь может быть какое-то сообщение {0}", rnd.Next(1000)), LikesCount = rnd.Next(1000), ImageUrl = string.Format("http://wishlist.com/{0}.jpg", rnd.Next(1000000)) });
            }
        }

        #endregion

        public void Dispose()
        {
            _userPosts.Clear();
        }

        public UserPostEntity Get(long id)
        {
            return _userPosts.SingleOrDefault(r => r.Id == id);
        }

        public Collection<UserPostEntity> Get(int userId, int boardId)
        {
            Collection<UserPostEntity> posts = new Collection<UserPostEntity>();

            foreach (UserPostEntity post in _userPosts.Where(r => r.AuthorUserId == userId && r.BoardId == boardId))
                posts.Add(post);

            return posts;
        }
    }
}

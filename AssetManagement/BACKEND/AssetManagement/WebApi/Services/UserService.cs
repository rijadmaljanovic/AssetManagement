using Models.Model;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IUserService
    {
        void Create(CreateUserModel model);
        string GenerateHash(string salt, string password);
        string GenerateSalt();
        IEnumerable<User> GetAll();
        User GetById(string id);
    }
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Create(CreateUserModel model)
        {
            string salt = GenerateSalt();
            string hash = GenerateHash(salt, model.Password);
            User novi = new User()
            {
                PartitionKey = model.Username,
                RowKey = Guid.NewGuid().ToString(),
                Name=model.Name,
                LastName=model.LastName,
                Email=model.Email,
                Address=model.Address,
                City=model.City,
                ZipCode=model.ZipCode,
                Username=model.Username,
                PasswordSalt = salt,
                Hash = hash
            };
            userRepository.CreateOrUpdate(novi);
        }

        public string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.All();
        }
        public User GetById(string id)
        {
            return userRepository.All().FirstOrDefault(x => x.RowKey == id);
        }
    }
}

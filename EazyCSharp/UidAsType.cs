namespace EazyCSharp
{
    internal class UidAsType
    {
        private readonly Dictionary<UserUid, User> users = new Dictionary<UserUid, User>();

        public UidAsType()
        {
            var user1 = new User(new UserUid("qwerty"), "Naruto");
            users.Add(user1.Uid, user1);

            var user2 = new User(new UserUid("abcdef"), "Sasuke");
            users.Add(user2.Uid, user2);

            var user3 = new User(new UserUid("asdfgh"), "Sakura");
            users.Add(user3.Uid, user3);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Введите uid: ");
                    var uid = Console.ReadLine();

                    if (uid == "exit")
                    {
                        break;
                    }

                    var userUid = new UserUid(uid ?? string.Empty);
                    var user = FirstOrDefault(userUid);

                    if (user is null)
                    {
                        Console.WriteLine("Пользователь не найден");
                    }
                    else
                    {
                        Console.WriteLine(user);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Write("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
            }
        }

        private User? FirstOrDefault(UserUid userUid)
        {
            if (users.ContainsKey(userUid))
            {
                return users[userUid];
            }
            return null;
        }
    }

    class User
    {
        public UserUid Uid { get; set; }

        public string Name { get; private set; }

        public User(UserUid uid, string name)
        {
            Uid = uid;
            Name = name;
        }

        public override string ToString()
        {
            return $"{{Uid={Uid}, Name={Name}}}";
        }
    }

    class UserUid
    {
        public string Value { get; private set; }

        public UserUid(string uid)
        {
            if (uid.Length != 6 || !uid.All(x => char.IsLetter(x)))
            {
                throw new ArgumentException("Не корректный идентификатор");
            }
            Value = uid;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is UserUid userUid && userUid.Value == Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}

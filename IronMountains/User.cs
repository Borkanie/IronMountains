using MySql.Data.MySqlClient;
using System;

namespace IronMountains
{

    class User : IDisposable
    {
        //Class that represents a row from the database for better managment
        public User(MySqlDataReader reader)
        {
            if (reader.FieldCount == 4)
            {
                this.Id = Convert.ToInt32(reader.GetString(0));
                this.Username = reader.GetString(1);
                this.Password = reader.GetString(2);
                this.Role = new Role(reader.GetString(3));

            }
        }
        //One property per Column
        #region Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        #endregion
        #region Methods
        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);

        }
        public override string ToString()
        {
            return "user:" + this.Username + " with password:" + this.Password;
        }
        public override bool Equals(object obj)
        {
            if (!this.GetType().Equals(obj.GetType()) || obj == null)
                return false;
            else
            {
                User dummy = (User)obj;
                if (this.Role != dummy.Role || this.Id != dummy.Id || this.Password != dummy.Password || this.Username != dummy.Username)
                    return false;

            }
            return true;
        }
        public override int GetHashCode()
        {
            if (String.IsNullOrEmpty(this.Username) || String.IsNullOrEmpty(this.Password))
                return 0;
            return this.Username.GetHashCode() * this.Password.GetHashCode() * this.Role.GetHashCode();
        }
        #endregion
    }
}

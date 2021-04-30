using System;

namespace IronMountains
{
    //all the possible roles in our database
    public enum Roles
    {
        Admin,
        User,
        Intern
    }
    //Role class i needed to implement Idisposable for using statement
    //created it just for better logical managment of the users
    class Role : IDisposable
    {
        public Role(string role)
        {

            switch (role)
            {
                case "Admin":
                    this.Rol = Roles.Admin;
                    break;
                case "User":
                    this.Rol = Roles.User;
                    break;
                case "Intern":
                    this.Rol = Roles.Intern;
                    break;
                default:

                    break;
            }
        }
        //only one property
        public Roles Rol { get; set; }
        #region Methods
        public Roles GetRole()
        {

            return this.Rol;
        }
        public override string ToString()
        {
            return Rol.ToString();
        }
        public override bool Equals(object obj)
        {
            if (!this.GetType().Equals(obj.GetType()) || obj == null)
                return false;
            else
            {
                Role dummy = (Role)obj;
                if (this.Rol != dummy.Rol)
                    return false;

            }
            return true;
        }
        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);

        }

        public override int GetHashCode()
        {
            if (this.Rol == null)
                return 0;
            if (this.Rol == Roles.Admin)
                return 1;
            if (this.Rol == Roles.Intern)
                return 3;
            if (this.Rol == Roles.User)
                return 2;
            return 0;
        }
        #endregion
    }
}

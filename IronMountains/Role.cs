using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IronMountains
{
    public enum Roles
    {
        Admin,
        User,
        Intern
    }
    class Role : IDisposable
    {
        public Roles Rol{get;set;}
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
            if (!this.GetType().Equals(obj.GetType())||obj==null)
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
    }
}

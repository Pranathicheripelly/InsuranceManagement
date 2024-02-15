using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IAdminRepository
    {
        // Create
        //The methods declared in the interface represent basic CRUD (Create, Read, Update, Delete) operations for
        //an entity named Admin. For example, CreateAdmin is a method to create a new admin.
        Admin CreateAdmin(Admin admin);

        // Read
        // AdminExistsEmail checks if an admin with a specific email exists.
        bool AdminExistsEmail(string UserEmail);
        //AdminExists checks if an admin with a specific username exists.
        bool AdminExists(string userName);
        //GetAdminById retrieves an admin based on their ID.
        Admin GetAdminById(int adminId);
        //GetAllAdmins retrieves all admins.
        IEnumerable<Admin> GetAllAdmins();

        // Update
        //The Update section has a method UpdateAdmin for updating the information of an existing admin.
        //its modifying the data and returns the updates.
        Admin UpdateAdmin(Admin admin);

        // Delete
        //The Delete section includes methods for deleting an admin by ID (DeleteAdmin)
        Admin DeleteAdmin(int adminId);
        //getting an admin by username (GetAdminByUserName)
        Admin GetAdminByUserName(string userName);
        //SaveAdminChanges is a method that typically commits changes to the underlying data store.
        void SaveAdminchages();


        //This method, GetAdminByUserNamePhone, retrieves an admin based on both username and phone number.
        Admin GetAdminByUserNamePhone(string userName, string phoneNumber);

    }
}

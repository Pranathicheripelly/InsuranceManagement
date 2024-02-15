using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using UI.Models;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        private InsuranceDbContext dbContext;
        public CustomerController()
        {
            dbContext = new InsuranceDbContext(); // Initialize your DbContext
        }
        // GET: Customer

        //This action method (Dashboard) returns a view. It is intended to display the dashboard for the customer.
        public ActionResult Dashboard()
        {
            return View();//retuen a view related to the customer dashboard
        }
        //(GetAllCustomers) retrieves all customers from the database and returns a view with a list of customers.
        public ActionResult GetAllCustomers()
        {
            //(DbContext) simplifies database interactions, provides a convenient way to work with your domain mode
            var customers = dbContext.Customers.ToList();
            return View(customers);
        }

        // Action method to get all users
 //(GetAllUsers) retrieves all users (customers, assuming they are stored in the same table) and returns a view with a list of users.
        public ActionResult GetAllUsers()
        {
            var users = dbContext.Customers.ToList(); // Assuming users are stored in the same table as customers
            return View(users);
        }


        public ActionResult ViewPoliciesToApply()//It is responsible for handling HTTP requests and producing the appropriate HTTP response.
        {
       List<Policy> policies = dbContext.Policies.ToList();//(dbcontact)used to interact with the database.
            return View(policies);// view is responsible for rendering the HTML that is sent to the browser.
        }
        //this action method handles the process of a customer applying for a policy. It checks if the customer has
        //already applied for the specified policy, retrieves the policy details, creates an AppliedPolicy object, adds
        //it to the database, and then redirects the user to a page displaying applied policies.

        public ActionResult Apply(int policyId)
        {
            // Replace the logic below with your code to get the actual customer ID
            int customerId = 1;

            // Check if the customer has already applied for the policy
            bool alreadyApplied = dbContext.AppliedPolicies
                .Any(ap => ap.CustomerId == customerId && ap.AppliedPolicyId == policyId);

            if (!alreadyApplied)
            {
                // Retrieve the policy details
                Policy policy = dbContext.Policies.FirstOrDefault(p => p.PolicyId == policyId);

                if (policy != null)
                {
                    // Create an AppliedPolicy object
                    AppliedPolicy appliedPolicy = new AppliedPolicy
                    {
                        PolicyNumber = policy.PolicyNumber,
                        AppliedDate = DateTime.Now,
                        Category = policy.Category,
                        CustomerId = customerId
                    };

                    // Add the applied policy to the database
                    dbContext.AppliedPolicies.Add(appliedPolicy);
                    dbContext.SaveChanges();
                }
                else
                {
                    // Handle the case where the policy with the specified ID doesn't exist
                    // You might want to add logging or return an appropriate response to the user.
                }
            }

            // Redirect to the action that shows applied policies
            return RedirectToAction("AppliedPolicies");
        }


        //this action method retrieves a list of applied policies from the database using Entity Framework, stores them
        //in a list, and then returns a view result along with the list of applied policies.
        public ActionResult AppliedPolicies()
        {
    //Declares a variable named . This variable will be used to store the list of applied policies retrieved from the database.
            List<AppliedPolicy> appliedPolicies;
            // Starts a using block, creating a new instance of the InsuranceDbContext
            using (var dbContext = new InsuranceDbContext())
            {
                // Retrieve applied policies from the database
                appliedPolicies = dbContext.AppliedPolicies.ToList();
            }

            return View(appliedPolicies);
        }




        public ActionResult Categories()
        {
            //This line uses the dbContext  to interact with the database.
            var categories = dbContext.Categories.ToList();
            return View(categories);
        }


        //AskQuestion action method is likely associated with a view that allows users to ask questions.
        public ActionResult AskQuestion()
        {
            return View();
        }

        
        [HttpPost]  //It is commonly used for form submissions where data is sent to the server.

        //It ensures that the form data is submitted by the same application and not from an external source.
        [ValidateAntiForgeryToken]
        public ActionResult AskQuestion(QuestionView questionView)
        {
           
            if (ModelState.IsValid) // Checks whether the model state is valid
            {
                // Create a new Questions entity
                Questions newQuestion = new Questions
                {
                    Question = questionView.Question,
                    Date = questionView.Date,
                    Answer = questionView.Answer,         //represents the data submitted in the form.
                    CustomerId = questionView.CustomerId
                };

                // Add the new question to the database
                dbContext.Questions.Add(newQuestion);
                dbContext.SaveChanges();

                // Redirect to a success page or display a success message
                //model state is valid and the question is successfully added to the database
                return RedirectToAction("Success");
            }

            // If ModelState is not valid, return to the AskQuestion view with the validation errors
            return View(questionView);
        }


        public ActionResult Success()
        {
            return View();
        }

        // Add any other actions or methods as needed

        //The Dispose method is typically called when the controller is no longer needed, for example, when it goes
        //out of scope or when explicitly called by user code.

        protected override void Dispose(bool disposing)//  dispose will perform cleam up actions.
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }




        public ActionResult AskCustomerId()
        {
            return View();
        }

        // Action method to display questions for the specified customer ID

        [HttpPost]//action method should respond only to HTTP POST requests.
        public ActionResult DisplayQuestionsByCustomerId(int? customerId)
        {
            // Check if customerId is null
            if (!customerId.HasValue)
            {
                // Handle the case when customerId is null, for example, redirect to an error page or return a specific view
                return RedirectToAction("Error");
            }

            // Retrieve all questions associated with the specified customerId
            var questions = dbContext.Questions.Where(q => q.CustomerId == customerId.Value).ToList();

            // Pass the list of questions and customer ID to the view
            ViewBag.CustomerId = customerId.Value;
            return View(questions);
        }

    }

}

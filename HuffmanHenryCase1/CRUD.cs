using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HuffmanHenryCase1
{
    [Activity(Label = "CRUD")]
    public class CRUD : Activity
    {
        private int currentIndex = 0;
        EditText etEmployeeId;
        EditText etLastName;
        EditText etFirstName;
        EditText etHourlyWage;
        EditText etHoursWorked;
        EditText etTotalPayroll;
        TextView tvCRUDError;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.Title = "Oh CRUD...";

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CRUD);

            etEmployeeId = (EditText)FindViewById(Resource.Id.etEmployeeId);
            etLastName = (EditText)FindViewById(Resource.Id.etLastName);
            etFirstName = (EditText)FindViewById(Resource.Id.etFirstName);
            etHourlyWage = (EditText)FindViewById(Resource.Id.etHourlyWage);
            etHoursWorked = (EditText)FindViewById(Resource.Id.etHoursWorked);
            etTotalPayroll = (EditText)FindViewById(Resource.Id.etTotalPayroll);
            tvCRUDError = (TextView)FindViewById(Resource.Id.tvCRUDError);


            Button btnPrevious = (Button)FindViewById(Resource.Id.btnPrevious);
            btnPrevious.Click += BtnPrevious_Click;

            Button btnNext = (Button)FindViewById(Resource.Id.btnNext);
            btnNext.Click += BtnNext_Click;

            Button btnFindId = (Button)FindViewById(Resource.Id.btnFindId);
            btnFindId.Click += BtnFindId_Click;

            Button btnCreate = (Button)FindViewById(Resource.Id.btnCreate);
            btnCreate.Click += BtnCreate_Click;

            Button btnUpdate = (Button)FindViewById(Resource.Id.btnUpdate);
            btnUpdate.Click += BtnUpdate_Click;

            Button btnDelete = (Button)FindViewById(Resource.Id.btnDelete);
            btnDelete.Click += BtnDelete_Click;

            Button btnBack = (Button)FindViewById(Resource.Id.btnBack);
            btnBack.Click += BtnBack_Click;

            showCurrent(currentIndex);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Intent returnToOperations = new Intent(this, typeof(Operations));
            SetResult(Result.Ok, returnToOperations);
            Finish();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(MainActivity.EmployeeListSortedByLastName.Count == 0)
            {
                tvCRUDError.Text = "There are no more employees... you got them all.";
            }
            else
            {
                //at the beginning
                if(MainActivity.EmployeeListSortedByLastName.Count == 1)
                {
                    MainActivity.EmployeeListSortedByLastName.RemoveAt(currentIndex);
                    etEmployeeId.Text = "";
                    etFirstName.Text = "";
                    etLastName.Text = "";
                    etHourlyWage.Text = "";
                    etHoursWorked.Text = "";
                    etTotalPayroll.Text = "";
                }
                else if (MainActivity.EmployeeListSortedByLastName.Count-1 == currentIndex)
                {
                    MainActivity.EmployeeListSortedByLastName.RemoveAt(currentIndex);
                    currentIndex--;
                    showCurrent(currentIndex);
            
                }
                else
                {
                    MainActivity.EmployeeListSortedByLastName.RemoveAt(currentIndex);
                    showCurrent(currentIndex); 
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            tvCRUDError.Text = "";

            if(MainActivity.EmployeeListSortedByLastName.Count == 0)
            {
                currentIndex = 0;
                Employee person = Employee.makeEmployee();
                MainActivity.EmployeeListSortedByLastName.Add(person.employeeId, person);
                MainActivity.numberOfEmployees++;
                showCurrent(currentIndex);
            }
            else
            {
                currentIndex = MainActivity.EmployeeListSortedByLastName.Count;
                Employee person = Employee.makeEmployee();
                MainActivity.EmployeeListSortedByLastName.Add(person.employeeId, person);
                MainActivity.numberOfEmployees++;
                showCurrent(currentIndex);
            }

        }

        private void BtnFindId_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if(MainActivity.EmployeeListSortedByLastName.Count != 0)
            {
                if (currentIndex >= MainActivity.EmployeeListSortedByLastName.Count - 1)
                {
                    tvCRUDError.Text = "STAHP! Already at the last index.";
                }
                else
                {
                    currentIndex++;
                    showCurrent(currentIndex);
                    tvCRUDError.Text = "";
                }
            }
            else
            {
                tvCRUDError.Text = "Man this sorted list is empty, try the create button.";
            }

        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if(MainActivity.EmployeeListSortedByLastName.Count != 0)
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                    showCurrent(currentIndex);
                    tvCRUDError.Text = "";
                }
                else
                {
                    tvCRUDError.Text = "YOU SHALL NOT BACK! At first index already.";
                }
            }

            else
            {
                tvCRUDError.Text = "Man this sorted list is empty, try the create button.";
            }

        }

        private void showCurrent(int index)
        {
            Employee s;
            KeyValuePair<int, Employee> keyPair;
            keyPair = MainActivity.EmployeeListSortedByLastName.ElementAt(index);
            s = MainActivity.EmployeeListSortedByLastName[keyPair.Key];

            etEmployeeId.Text = s.employeeId.ToString();
            etFirstName.Text = s.firstName.ToString();
            etLastName.Text = s.firstName.ToString();
            etHourlyWage.Text = s.hourlyWage.ToString("0.00");
            etHoursWorked.Text = s.hoursWorked.ToString("0.00");
            etTotalPayroll.Text = s.totalPayRoll.ToString("0.00"); 
        }
    }
}
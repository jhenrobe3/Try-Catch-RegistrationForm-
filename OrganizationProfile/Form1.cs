using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public long StudentNumber(string studNum)
        {
            if (Regex.IsMatch(studNum, @"^[0-9]{10,15}$"))
            {
                _StudentNo = long.Parse(studNum);
            }
            else
            {
                throw new ArgumentNullException("Invalid input! Please input valid student number");
            }

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid input! Please input valid contact number.");
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
                throw new FormatException("Invalid input! Please complete your full name.");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,2}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new OverflowException("Input valid age.");
            }

            return _Age;
        }
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systerm",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
            string[] ListOfGender = new string[]{
                "Male",
                "Female",
                "Transgender",
                "Prefer not to respond"
            };
            for (int i = 0; i < 4; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");


                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            catch (FormatException FE)
            {
                MessageBox.Show("Message: " + FE.Message);
            }
            catch (IndexOutOfRangeException IRE)
            {
                MessageBox.Show("Message: " + IRE.Message);
            }
            catch (ArgumentNullException AE)
            {
                MessageBox.Show("Message: " + AE.Message);
            }
            catch (OverflowException OE)
            {
                MessageBox.Show("Message: " + OE.Message);
            }
            finally
            {
                //execute everytime
            }
        }
    }
}
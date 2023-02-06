using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPaymentSystem
{
    public partial class Form1 : Form
    {
        String studentName;
        String studentIC;
        String studentCategory;
        String exemptionType;
        Boolean hostelStudent;
        int REGFEE = 20;
        int INSURANCE = 30;
        int EXAMFEE = 15;
        int PEFOUND = 30;
        int STUCOM = 10;
        int STUACT = 30;
        int DEVFOUND = 100;
        int SCHOOLBADGE = 10;
        int NEWCAMP = 60;
        int RESULTSMS = 15;
        int HOSTELFOUND = 200;
        int HOSTELCOM = 30;
        int JANHOSTEL = 80;
        int JANFNB = 80;
        int ELECTRICITY = 50;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkFeeButton_Click(object sender, EventArgs e)
        {
            // Check Input and Assign Values to Variables
            try
            {
                studentName = nameTxtbox.Text;
                studentIC = studentICtxtBox.Text;
                studentCategory = categoryComboBox.SelectedItem.ToString();
                hostelStudent = hostelStudentButton.Checked;

                if(String.IsNullOrEmpty(studentName) || String.IsNullOrEmpty(studentIC))
                {
                    throw new Exception();
                }
                if (halfExemptedButton.Checked)
                {
                    exemptionType = "HALF";
                }
                else if (fullyExemptedButton.Checked)
                {
                    exemptionType = "FULL";
                }
                else if (notExemptedButton.Checked)
                {
                    exemptionType = "NO";
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("请完整输入资料！","提示");
            }

            // Amount Added to Table According to Student Category





            // Show Break Down Table According to Student Category

        
            if(studentName != null && studentIC != null && studentCategory != null && exemptionType != null)
            {
                if(exemptionType == "NO")
                {
                    tuitionFeeTxtBox.Text = "250";
                }else if(exemptionType == "HALF")
                {
                    tuitionFeeTxtBox.Text = "155";
                }else if(exemptionType == "FULL")
                {
                    tuitionFeeTxtBox.Text = "60";
                }
                updateNewStudentFee();
                checkAllCBox();
                updateActualStudentPayment();
                FeeBreakDownTable.Visible = true;


                if (hostelStudent)
                {
                    updateHostelFee();
                    checkAllCBox();
                    updateActualHostelStudentPayment();
                    hostelFeeBreakDownTable.Visible = true;
                }

                int totalFee = 0;
                int actualFee = 0;
                totalFee += System.Convert.ToInt32(totalAmountLbl.Text);
                actualFee += System.Convert.ToInt32(actualPayLabel.Text);
                if (hostelStudent)
                {
                    totalFee += System.Convert.ToInt32(hostelAmountLabel.Text);
                    actualFee += System.Convert.ToInt32(hostelActualAmountLabel.Text);
                }

                totalAmountLabel.Text = totalFee.ToString();
                actualAmountLabel.Text = actualFee.ToString();
                totalBalanceLabel.Text = (System.Convert.ToInt32(totalAmountLabel.Text) - System.Convert.ToInt32(actualAmountLabel.Text)).ToString();

                payTable.Visible = true;
                inputPanel.Enabled = false;

                Console.WriteLine(hostelAmountLabel.Text);
            }
     
            
        }

        private void updateNewStudentFee()
        {
            int totalAmount = 0;
            if (regFeeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(regFeeLabel.Text);
            }
            if (insuranceFeeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(insuranceLabel.Text);
            }
            if (examFeeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(examFeeLabel.Text);
            }
            if (PEFoundationCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(peFoundationLabel.Text);
            }
            if (stuComFoundationCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(stuComLabel.Text);
            }
            if (stuActivityFoundationCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(stuActLabel.Text);
            }
            if (devFoundationCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(devFoundLabel.Text);
            }
            if (janTuitionFeeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(tuitionFeeTxtBox.Text);
            }
            if (schoolBadgeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(schoolBadgeLabel.Text);
            }
            if (newStudentCampCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(newStuCampFee.Text);
            }
            if (resultSMSCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(resultSMSLabel.Text);
            }

            totalAmountLbl.Text = totalAmount.ToString();
        }

        private void regFeeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if(regFeeCBox.Checked == false)
            {
                payReg.Checked = false;
                payReg.Enabled = false;
            }
            else
            {
                payReg.Checked = true;
                payReg.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void insuranceFeeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (insuranceFeeCBox.Checked == false)
            {
                payInsurance.Checked = false;
                payInsurance.Enabled = false;
            }
            else
            {
                payInsurance.Checked = true;
                payInsurance.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void examFeeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (examFeeCBox.Checked == false)
            {
                payExam.Checked = false;
                payExam.Enabled = false;
            }
            else
            {
                payExam.Checked = true;
                payExam.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void PEFoundationCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PEFoundationCBox.Checked == false)
            {
                payPE.Checked = false;
                payPE.Enabled = false;
            }
            else
            {
                payPE.Checked = true;
                payPE.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void stuComFoundationCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stuComFoundationCBox.Checked == false)
            {
                payStuCom.Checked = false;
                payStuCom.Enabled = false;
            }
            else
            {
                payStuCom.Checked = true;
                payStuCom.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void stuActivityFoundationCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stuActivityFoundationCBox.Checked == false)
            {
                payStuAct.Checked = false;
                payStuAct.Enabled = false;
            }
            else
            {
                payStuAct.Checked = true;
                payStuAct.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void devFoundationCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (devFoundationCBox.Checked == false)
            {
                payDev.Checked = false;
                payDev.Enabled = false;
            }
            else
            {
                payDev.Checked = true;
                payDev.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void janTuitionFeeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (janTuitionFeeCBox.Checked == false)
            {
                payJanTui.Checked = false;
                payJanTui.Enabled = false;
                tuitionFeeTxtBox.Enabled = false;
            }
            else
            {
                payJanTui.Checked = true;
                payJanTui.Enabled = true;
                tuitionFeeTxtBox.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void schoolBadgeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (schoolBadgeCBox.Checked == false)
            {
                paySchoolBadge.Checked = false;
                paySchoolBadge.Enabled = false;
            }
            else
            {
                paySchoolBadge.Checked = true;
                paySchoolBadge.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void newStudentCampCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (newStudentCampCBox.Checked == false)
            {
                payCamp.Checked = false;
                payCamp.Enabled = false;
            }
            else
            {
                payCamp.Checked = true;
                payCamp.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void resultSMSCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (resultSMSCBox.Checked == false)
            {
                payResult.Checked = false;
                payResult.Enabled = false;
            }
            else
            {
                payResult.Checked = true;
                payResult.Enabled = true;
            }
            updateNewStudentFee();
        }

        private void tuitionFeeTxtBox_TextChanged(object sender, EventArgs e)
        {
            updateNewStudentFee();
            updateActualStudentPayment();
        }

        private void totalAmountLbl_TextChanged(object sender, EventArgs e)
        {
            int total = System.Convert.ToInt32(totalAmountLbl.Text) + System.Convert.ToInt32(hostelAmountLabel.Text);
            totalAmountLabel.Text = total.ToString();
        }

        private void actualPayLabel_TextChanged(object sender, EventArgs e)
        {
            int total = System.Convert.ToInt32(actualPayLabel.Text) + System.Convert.ToInt32(hostelActualAmountLabel.Text);
            actualAmountLabel.Text = total.ToString();
        }

        private void hostelAmountLabel_TextChanged(object sender, EventArgs e)
        {
            int total = System.Convert.ToInt32(totalAmountLbl.Text) + System.Convert.ToInt32(hostelAmountLabel.Text);
            totalAmountLabel.Text = total.ToString();
        }

        private void hostelActualAmountLabel_TextChanged(object sender, EventArgs e)
        {
            int total = System.Convert.ToInt32(actualPayLabel.Text) + System.Convert.ToInt32(hostelActualAmountLabel.Text);
            actualAmountLabel.Text = total.ToString();
        }

        private void totalAmountLabel_TextChanged(object sender, EventArgs e)
        {
            int balance = System.Convert.ToInt32(totalAmountLabel.Text) - System.Convert.ToInt32(actualAmountLabel.Text);
            totalBalanceLabel.Text = balance.ToString();
        }


        private void actualAmountLabel_TextChanged(object sender, EventArgs e)
        {
            int balance = System.Convert.ToInt32(totalAmountLabel.Text) - System.Convert.ToInt32(actualAmountLabel.Text);
            totalBalanceLabel.Text = balance.ToString();
        }
        private void updateHostelFee()
        {
            int totalAmount = 0;
            if (hostelFoundationCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(hostelFoundLabel.Text);
            }
            if (hostelComFoundationCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(hostelComFoundationLabel.Text);
            }
            if (janHostelFeeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(janHostelLabel.Text);
            }
            if (janFnBFeeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(janFnBLabel.Text);
            }
            if (electricityFeeCBox.Checked)
            {
                totalAmount += System.Convert.ToInt32(electricityLabel.Text);
            }
            hostelAmountLabel.Text = totalAmount.ToString();
        }

        private void hostelFoundationCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hostelFoundationCBox.Checked == false)
            {
                payHosFound.Checked = false;
                payHosFound.Enabled = false;
            }
            else
            {
                payHosFound.Checked = true;
                payHosFound.Enabled = true;
            }
            updateHostelFee();
        }

        private void hostelComFoundationCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hostelComFoundationCBox.Checked == false)
            {
                payHosCom.Checked = false;
                payHosCom.Enabled = false;
            }
            else
            {
                payHosCom.Checked = true;
                payHosCom.Enabled = true;
            }
            updateHostelFee();
        }

        private void janHostelFeeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (janHostelFeeCBox.Checked == false)
            {
                payJanHos.Checked = false;
                payJanHos.Enabled = false;
            }
            else
            {
                payJanHos.Checked = true;
                payJanHos.Enabled = true;
            }
            updateHostelFee();
        }

        private void janFnBFeeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (janFnBFeeCBox.Checked == false)
            {
                payJanFnB.Checked = false;
                payJanFnB.Enabled = false;
            }
            else
            {
                payJanFnB.Checked = true;
                payJanFnB.Enabled = true;
            }
            updateHostelFee();
        }

        private void electricityFeeCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (electricityFeeCBox.Checked == false)
            {
                payElectricity.Checked = false;
                payElectricity.Enabled = false;
            }
            else
            {
                payElectricity.Checked = true;
                payElectricity.Enabled = true;
            }
            updateHostelFee();
        }

        private void updateActualStudentPayment()
        {
            int totalAmount = 0;
            if (payReg.Checked)
            {
                totalAmount += System.Convert.ToInt32(regFeeLabel.Text);
            }
            if (payInsurance.Checked)
            {
                totalAmount += System.Convert.ToInt32(insuranceLabel.Text);
            }
            if (payExam.Checked)
            {
                totalAmount += System.Convert.ToInt32(examFeeLabel.Text);
            }
            if (payPE.Checked)
            {
                totalAmount += System.Convert.ToInt32(peFoundationLabel.Text);
            }
            if (payStuCom.Checked)
            {
                totalAmount += System.Convert.ToInt32(stuComLabel.Text);
            }
            if (payStuAct.Checked)
            {
                totalAmount += System.Convert.ToInt32(stuActLabel.Text);
            }
            if (payDev.Checked)
            {
                totalAmount += System.Convert.ToInt32(devFoundLabel.Text);
            }
            if (payJanTui.Checked)
            {
                totalAmount += System.Convert.ToInt32(tuitionFeeTxtBox.Text);
            }
            if (paySchoolBadge.Checked)
            {
                totalAmount += System.Convert.ToInt32(schoolBadgeLabel.Text);
            }
            if (payCamp.Checked)
            {
                totalAmount += System.Convert.ToInt32(newStuCampFee.Text);
            }
            if (payResult.Checked)
            {
                totalAmount += System.Convert.ToInt32(resultSMSLabel.Text);
            }
            actualPayLabel.Text = totalAmount.ToString();
        }

        private void updateActualHostelStudentPayment()
        {
            int totalAmount = 0;
            if (payHosFound.Checked)
            {
                totalAmount += System.Convert.ToInt32(hostelFoundLabel.Text);
            }
            if (payHosCom.Checked)
            {
                totalAmount += System.Convert.ToInt32(hostelComFoundationLabel.Text);
            }
            if (payJanHos.Checked)
            {
                totalAmount += System.Convert.ToInt32(janHostelLabel.Text);
            }
            if (payJanFnB.Checked)
            {
                totalAmount += System.Convert.ToInt32(janFnBLabel.Text);
            }
            if (payElectricity.Checked)
            {
                totalAmount += System.Convert.ToInt32(electricityLabel.Text);
            }
          
            hostelActualAmountLabel.Text = totalAmount.ToString();
        }

        private void checkAllCBox()
        {
            regFeeCBox.Checked = true;
            insuranceFeeCBox.Checked = true;
            examFeeCBox.Checked = true;
            PEFoundationCBox.Checked = true;
            stuComFoundationCBox.Checked = true;
            stuActivityFoundationCBox.Checked = true;
            devFoundationCBox.Checked = true;
            janTuitionFeeCBox.Checked = true;
            schoolBadgeCBox.Checked = true;
            newStudentCampCBox.Checked = true;
            resultSMSCBox.Checked = true;
            hostelFoundationCBox.Checked = true;
            hostelComFoundationCBox.Checked = true;
            janHostelFeeCBox.Checked = true;
            janFnBFeeCBox.Checked = true;
            electricityFeeCBox.Checked = true;
            payReg.Checked = true;
            payInsurance.Checked = true;
            payExam.Checked = true;
            payPE.Checked = true;
            payStuCom.Checked = true;
            payStuAct.Checked = true;
            payDev.Checked = true;
            payJanTui.Checked = true;
            paySchoolBadge.Checked = true;
            payCamp.Checked = true;
            payResult.Checked = true;
            payHosFound.Checked = true;
            payHosCom.Checked = true;
            payJanHos.Checked = true;
            payJanFnB.Checked = true;
            payElectricity.Checked = true;

           
          
        }

        private void payReg_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payInsurance_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payExam_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payPE_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payStuCom_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payStuAct_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payDev_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payJanTui_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void paySchoolBadge_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payCamp_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payResult_CheckedChanged(object sender, EventArgs e)
        {
            updateActualStudentPayment();
        }

        private void payHosFound_CheckedChanged(object sender, EventArgs e)
        {
            updateActualHostelStudentPayment();
        }

        private void payHosCom_CheckedChanged(object sender, EventArgs e)
        {
            updateActualHostelStudentPayment();
        }

        private void payJanHos_CheckedChanged(object sender, EventArgs e)
        {
            updateActualHostelStudentPayment();
        }

        private void payJanFnB_CheckedChanged(object sender, EventArgs e)
        {
            updateActualHostelStudentPayment();
        }

        private void payElectricity_CheckedChanged(object sender, EventArgs e)
        {
            updateActualHostelStudentPayment();
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认缴费？", "提示",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Insert Student Data
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\mrq_q\source\repos\StudentPaymentSystem\StudentPaymentSystem\PaymentSystem.mdb";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("INSERT into Student (StudentName, StudentIC) Values(@studentName, @studentIC)");
                cmd.Connection = conn;

                conn.Open();


                if (conn.State == ConnectionState.Open)
                {

                    cmd.Parameters.Add("@StudentName", System.Data.OleDb.OleDbType.VarChar).Value = studentName;
                    cmd.Parameters.Add("@StudentIC", System.Data.OleDb.OleDbType.VarChar).Value = studentIC;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Added");


                        conn.Close();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        MessageBox.Show(ex.Source);
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                }


                // Read Student ID
                System.Data.OleDb.OleDbCommand readIDCommand = new System.Data.OleDb.OleDbCommand(" SELECT top 1 * from Student WHERE StudentIC = @studentIC", conn);
                conn.Open();
                int studentID = -1;
                if (conn.State == ConnectionState.Open)
                {

                    readIDCommand.Parameters.Add("@StudentIC", System.Data.OleDb.OleDbType.VarChar).Value = studentIC;

                    try
                    {
                        System.Data.OleDb.OleDbDataReader DB_Reader = readIDCommand.ExecuteReader();
                        if (DB_Reader.HasRows)
                        {
                            DB_Reader.Read();
                            studentID = DB_Reader.GetInt32(0);
                        }
                        Console.WriteLine(studentID);
                        MessageBox.Show("ID Added");

                        conn.Close();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        MessageBox.Show(ex.Source);
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                }



                // Prepare data for payment record inserting
                int regFee = 0;
                int insurFee = 0;
                int examFee = 0;
                int peFee = 0;
                int stuCom = 0;
                int stuAct = 0;
                int devFound = 0;
                int janTui = 0;
                int sBadge = 0;
                int campFee = 0;
                int resultFee = 0;
                int hosFound = 0;
                int hosComFound = 0;
                int janHos = 0;
                int janFNB = 0;
                int electricity = 0;

                if (regFeeCBox.Checked && payReg.Checked)
                {
                    regFee = REGFEE;
                }
                else if (regFeeCBox.Checked)
                {
                    regFee = 0 - REGFEE;
                }

                if (insuranceFeeCBox.Checked && payInsurance.Checked)
                {
                    insurFee = INSURANCE;
                }
                else if (insuranceFeeCBox.Checked)
                {
                    insurFee = 0 - INSURANCE;
                }

                if (examFeeCBox.Checked && payExam.Checked)
                {
                    examFee = EXAMFEE;
                }
                else if (examFeeCBox.Checked)
                {
                    examFee = 0 - EXAMFEE;
                }

                if (PEFoundationCBox.Checked && payPE.Checked)
                {
                    peFee = PEFOUND;
                }
                else if (PEFoundationCBox.Checked)
                {
                    peFee = 0 - PEFOUND;
                }

                if (stuComFoundationCBox.Checked && payStuCom.Checked)
                {
                    stuCom = STUCOM;
                }
                else if (stuComFoundationCBox.Checked)
                {
                    stuCom = 0 - STUCOM;
                }

                if (stuActivityFoundationCBox.Checked && payStuAct.Checked)
                {
                    stuAct = STUACT;
                }
                else if (stuActivityFoundationCBox.Checked)
                {
                    stuAct = 0 - STUACT;
                }
                if (devFoundationCBox.Checked && payDev.Checked)
                {
                    devFound = DEVFOUND;
                }
                else if (devFoundationCBox.Checked)
                {
                    devFound = 0 - DEVFOUND;
                }
                if (janTuitionFeeCBox.Checked && payJanTui.Checked)
                {
                    janTui = System.Convert.ToInt32(tuitionFeeTxtBox.Text);
                }
                else if (janTuitionFeeCBox.Checked)
                {
                    janTui = 0 - System.Convert.ToInt32(tuitionFeeTxtBox.Text);
                }
                if (schoolBadgeCBox.Checked && paySchoolBadge.Checked)
                {
                    sBadge = SCHOOLBADGE;
                }
                else if (schoolBadgeCBox.Checked)
                {
                    sBadge = 0 - SCHOOLBADGE;
                }
                if (newStudentCampCBox.Checked && payCamp.Checked)
                {
                    campFee = NEWCAMP;
                }
                else if (newStudentCampCBox.Checked)
                {
                    campFee = 0 - NEWCAMP;
                }
                if (resultSMSCBox.Checked && payResult.Checked)
                {
                    resultFee = RESULTSMS;
                }
                else if (resultSMSCBox.Checked)
                {
                    resultFee = 0 - RESULTSMS;
                }

                if (hostelStudent)
                {
                    if (hostelFoundationCBox.Checked && payHosFound.Checked)
                    {
                        hosFound = HOSTELFOUND;
                    }
                    else if (hostelFoundationCBox.Checked)
                    {
                        hosFound = 0 - HOSTELFOUND;
                    }

                    if (hostelComFoundationCBox.Checked && payHosCom.Checked)
                    {
                        hosComFound = HOSTELCOM;
                    }
                    else if (hostelComFoundationCBox.Checked)
                    {
                        hosComFound = 0 - HOSTELCOM;
                    }

                    if (janHostelFeeCBox.Checked && payJanHos.Checked)
                    {
                        janHos = JANHOSTEL;
                    }
                    else if (janHostelFeeCBox.Checked)
                    {
                        janHos = 0 - JANHOSTEL;
                    }

                    if (janFnBFeeCBox.Checked && payJanFnB.Checked)
                    {
                        janFNB = JANFNB;
                    }
                    else if (janFnBFeeCBox.Checked)
                    {
                        janFNB = 0 - JANFNB;
                    }

                    if (electricityFeeCBox.Checked && payElectricity.Checked)
                    {
                        electricity = ELECTRICITY;
                    }
                    else if (electricityFeeCBox.Checked)
                    {
                        electricity = 0 - ELECTRICITY;
                    }
                }
                System.Data.OleDb.OleDbCommand insertPaymentCMD = new System.Data.OleDb.OleDbCommand("INSERT into PaymentRecord (StudentID,PayAt,RegFee,InsurFee,PEFee,StuComFee,StuActFee,DevFee,JanTuiFee,SBadgeFee,CampFee,ExamFee,ResultFee,HostelFound,HostelCom,JanHostel,JanFNB,Electricity,Balance) " +
                    "Values(@studentID, @timeStamp,@regFee,@insurFee,@peFee,@stuCom,@stuAct,@devFee,@janTui,@sBadge,@campFee,@examFee,@result,@hostelFound,@hostelCom,@janHostel,@janFNB,@electricity,@balance)");



                insertPaymentCMD.Connection = conn;

                conn.Open();


                if (conn.State == ConnectionState.Open)
                {


                    insertPaymentCMD.Parameters.Add("@studentID", System.Data.OleDb.OleDbType.VarChar).Value = studentID;
                    insertPaymentCMD.Parameters.Add("@timeStamp", System.Data.OleDb.OleDbType.VarChar).Value = DateTime.Now;
                    insertPaymentCMD.Parameters.Add("@regFee", System.Data.OleDb.OleDbType.VarChar).Value = regFee;
                    insertPaymentCMD.Parameters.Add("@insurFee", System.Data.OleDb.OleDbType.VarChar).Value = insurFee;
                    insertPaymentCMD.Parameters.Add("@peFee", System.Data.OleDb.OleDbType.VarChar).Value = peFee;
                    insertPaymentCMD.Parameters.Add("@stuCom", System.Data.OleDb.OleDbType.VarChar).Value = stuCom;
                    insertPaymentCMD.Parameters.Add("@stuAct", System.Data.OleDb.OleDbType.VarChar).Value = stuAct;
                    insertPaymentCMD.Parameters.Add("@devFee", System.Data.OleDb.OleDbType.VarChar).Value = devFound;
                    insertPaymentCMD.Parameters.Add("@janTui", System.Data.OleDb.OleDbType.VarChar).Value = janTui;
                    insertPaymentCMD.Parameters.Add("@sBadge", System.Data.OleDb.OleDbType.VarChar).Value = sBadge;
                    insertPaymentCMD.Parameters.Add("@campFee", System.Data.OleDb.OleDbType.VarChar).Value = campFee;
                    insertPaymentCMD.Parameters.Add("@examFee", System.Data.OleDb.OleDbType.VarChar).Value = examFee;
                    insertPaymentCMD.Parameters.Add("@result", System.Data.OleDb.OleDbType.VarChar).Value = resultFee;
                    insertPaymentCMD.Parameters.Add("@hostelFound", System.Data.OleDb.OleDbType.VarChar).Value = hosFound;
                    insertPaymentCMD.Parameters.Add("@hostelCom", System.Data.OleDb.OleDbType.VarChar).Value = hosComFound;
                    insertPaymentCMD.Parameters.Add("@janHostel", System.Data.OleDb.OleDbType.VarChar).Value = janHos;
                    insertPaymentCMD.Parameters.Add("@janFNB", System.Data.OleDb.OleDbType.VarChar).Value = janFNB;
                    insertPaymentCMD.Parameters.Add("@electricity", System.Data.OleDb.OleDbType.VarChar).Value = electricity;
                    insertPaymentCMD.Parameters.Add("@balance", System.Data.OleDb.OleDbType.VarChar).Value = System.Convert.ToInt32(totalBalanceLabel.Text);
                    try
                    {
                        insertPaymentCMD.ExecuteNonQuery();
                        MessageBox.Show("Data Added");


                        conn.Close();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        MessageBox.Show(ex.Source);
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                }
            }


        }
    }
}

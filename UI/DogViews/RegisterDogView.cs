using Hundehuset.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hundehuset.UI.DogViews
{
    public class RegisterDogView
    {
        private DogController dogController;
        private ShowProfileDogView showProfileDogView;

        public RegisterDogView(DogController dogController)
        {
            this.dogController = dogController;
            showProfileDogView = new();
        }

        public void ShowView()
        {
            bool registerDogExit = false;

            while (registerDogExit == false) // loop will run until x has been pressed
            {
                Console.Clear();
                Console.WriteLine("REGISTER NEW DOG");
                Console.WriteLine("Enter 'X' to return to main menu.");
                Console.Write("Please enter pedigree number: ");
                var pedigreeNumber = Console.ReadLine();

                if (pedigreeNumber.ToUpper() == "X") // x, will break the loop and return to NavigationView
                {
                    registerDogExit = true;
                }
                else if (!Regex.IsMatch(pedigreeNumber, @"^[a-zA-Z0-9]+$")) // if there is no input to pedigreeNumber or in wrong format
                {
                    Console.WriteLine("You must enter 'X' or a valid pedigree number (only letters and digits - no spaces or special characters)");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else if (!dogController.IsDogInDatabase(pedigreeNumber)) // no dog with the selected pedigreeNumber was found in our database
                {
                    //Create a new Dog, with the selected PedigreeNumber
                    Dog dog = new()
                    {
                        PedigreeNumber = pedigreeNumber
                    };

                    Console.WriteLine("ADDITIONAL INFO");
                    //Name
                    Console.Write("Please enter name of the dog: ");
                    string inputName = Console.ReadLine();

                    if (!string.IsNullOrEmpty(inputName)) //Dog will only be assigned a name if there is input
                    {
                        inputName = dog.Name;
                    }


                    //BirthDate
                    DateTime birthDate;
                    bool correctBirthDateInput = false;

                    while (correctBirthDateInput == false) // loops until there is a propor input
                    {
                        Console.Write("Please enter birthdate (dd-mm-yyyy): ");
                        string inputBirthDate = Console.ReadLine();

                        if (string.IsNullOrEmpty(inputBirthDate)) // there is no input
                        {
                            correctBirthDateInput = true; // stops the while loop
                        }
                        else if (DateTime.TryParse(inputBirthDate, out birthDate))
                        {
                            dog.BirthDate = birthDate;
                            correctBirthDateInput = true; // stops the while loop
                        }
                        else
                        {
                            Console.WriteLine("The entered birthdate is not in the proper format.");
                            // and the while loop starts over 
                        }
                    }

                    //Sex
                    bool correctSexInput = false;
                    char sex;

                    while (correctSexInput == false)
                    {
                        Console.Write("Please enter sex (T for female and H for male): ");
                        string inputSex = Console.ReadLine().ToUpper();

                        if (string.IsNullOrEmpty(inputSex)) // there is no input
                        {
                            correctSexInput = true;
                        }
                        else if (char.TryParse(inputSex, out sex)) // is it posible to parse the input to a char
                        {
                            if (sex == 'T' || sex == 'H')
                            {
                                dog.Sex = sex;
                                correctSexInput = true;
                            }
                            else // if the input can be converted, but is other than T or H
                            {
                                Console.WriteLine("The entered sex is not in the proper format.");
                                continue; // goes back to the start of the while loop
                            }
                        }
                        else
                        {
                            Console.WriteLine("The entered sex is not in the proper format.");
                            // and the while loop will start over
                        }
                    }

                    //ChipNumber
                    bool correctChipInput = false;
                    string inputChipNumber;

                    while (correctChipInput == false)
                    {
                        Console.Write("Please enter chipnumber: ");
                        inputChipNumber = Console.ReadLine();

                        if (string.IsNullOrEmpty(inputChipNumber)) //Will accept no input and continue to next property insertion
                        {
                            correctChipInput = true;
                        }
                        else if (Regex.IsMatch(inputChipNumber, @"^[a-zA-Z0-9-]+$")) //Checks whether the user input is entered properly. Accepts letters, digits and dash (-).
                            //Note that in the CSV-file some chipnumbers are written with spaces or "Chip:" is spelled out in it - we want to make the program to alter these when it loads them in.
                        {
                            dog.ChipNumber = inputChipNumber;
                            correctChipInput = true;
                        }
                        else //if input not entered properly
                        {
                            Console.WriteLine("The entered chipnumber is not in the proper format.");
                        }
                    }
                    //missing InbreedingCoefficient

                    //HdStatus
                    bool correctHdStatusInput = false;
                    char hdStatus;

                    while (correctHdStatusInput == false)
                    {
                        Console.Write("Please enter HD-status (A, B, C, D or E): ");
                        string inputHdStatus = Console.ReadLine().ToUpper();

                        if (string.IsNullOrEmpty(inputHdStatus)) // there is no input
                        {
                            correctHdStatusInput = true;
                        }
                        else if (char.TryParse(inputHdStatus, out hdStatus)) // it is possible to parse the input to a char
                        {
                            if (hdStatus == 'A' || hdStatus == 'B' || hdStatus == 'C' || hdStatus == 'D' || hdStatus == 'E')
                            {
                                dog.HdStatus = hdStatus;
                                correctHdStatusInput = true;
                            }
                            else // if the input can be converted, but is other than A, B, C, D or E
                            {
                                Console.WriteLine("The entered HD-status is not in the proper format.");
                                continue; // goes back to the start of the while loop
                            }
                        }
                        else // if the input can't be converted
                        {
                            Console.WriteLine("The entered HD-status is not in the proper format.");
                            // and the while loop will start over
                        }
                    }

                    //missing HD-index

                    //SpondylosisStatus
                    bool correctSpondylosisStatusInput = false;
                    int spondylosisStatus;

                    while (correctSpondylosisStatusInput == false)
                    {
                        Console.Write("Please enter Spondylosis status: ");
                        string inputSpondylosisStatus = Console.ReadLine();

                        if (string.IsNullOrEmpty(inputSpondylosisStatus)) // there is no input
                        {
                            correctSpondylosisStatusInput = true;
                        }
                        else if (int.TryParse(inputSpondylosisStatus, out spondylosisStatus)) // it is possible to parse the input to a char
                        {
                            if (spondylosisStatus >= 1 || spondylosisStatus <= 4)
                            {
                                dog.SpondylosisStatus = spondylosisStatus;
                                correctSpondylosisStatusInput = true;
                            }
                            else // if the input can be converted, but is other than 1, 2, 3 or 4
                            {
                                Console.WriteLine("The entered Spondylosis status is not in the proper format.");
                                continue; // goes back to the start of the while loop
                            }
                        }
                        else
                        {
                            Console.WriteLine("The entered Spondylosis status is not in the proper format.");
                            // and the while loop will start over
                        }
                    }

                    //HeartStatus
                    bool correctHeartStatusInput = false;
                    int heartStatus;

                    while (correctHeartStatusInput == false)
                    {
                        Console.Write("Please enter heart status: ");
                        string inputHeartStatus = Console.ReadLine();

                        if (string.IsNullOrEmpty(inputHeartStatus)) // there is no input
                        {
                            correctHeartStatusInput = true;
                        }
                        else if (int.TryParse(inputHeartStatus, out heartStatus)) // it is possible to parse the input to a char
                        {
                            if (heartStatus >= 1 || heartStatus <= 4)
                            {
                                dog.HeartStatus = heartStatus;
                                correctHeartStatusInput = true;
                            }
                            else // if the input can be converted, but is other than 1, 2, 3 or 4
                            {
                                Console.WriteLine("The entered heart status is not in the proper format.");
                                continue; // goes back to the start of the while loop
                            }
                        }
                        else
                        {
                            Console.WriteLine("The entered heart status is not in the proper format.");
                            // and the while loop will start over
                        }
                    }

                    //Color
                    bool correctColorInput = false;

                    while (correctColorInput == false)
                    {
                        Console.Write("Please enter color (RG, TG, RG/HV, TG/HV, ufarve): ");
                        string inputColor = Console.ReadLine().ToUpper();

                        if (string.IsNullOrEmpty(inputColor)) // there is no input
                        {
                            correctColorInput = true;
                        }
                        else if (inputColor == "RG" || inputColor == "TG" || inputColor == "RG/HV" || inputColor == "TG/HV" || inputColor == "UFARVE")
                        {
                            dog.Color = inputColor;
                            correctColorInput = true;
                        }
                        else // if the input is other than EMPTY, RG, TG, RG/HV, TG/HV or UFARVE
                        {
                            Console.WriteLine("The entered color is not in the proper format.");
                            // and the while loop will start over
                        }
                    }

                    //IsAlive
                    bool correctIsAliveInput = false;

                    while (correctIsAliveInput == false)
                    {
                        Console.Write("Is the dog alive? (yes, no): ");
                        string isAliveInput = Console.ReadLine().ToUpper();

                        if (string.IsNullOrEmpty(isAliveInput)) // there is no input
                        {
                            dog.IsAlive = true; // If nothing is selected, the dog will default be alive 
                            correctIsAliveInput = true;
                        }
                        else if (isAliveInput == "YES")
                        {
                            dog.IsAlive = true;
                            correctIsAliveInput = true;
                        }
                        else if (isAliveInput == "NO")
                        {
                            dog.IsAlive = false;
                            correctIsAliveInput = true;
                        }
                        else // the input is other than EMPTY, YES or NO
                        {
                            Console.WriteLine("The entered input is not in the proper format.");
                            // and the while loop will start over
                        }
                    }

                    //MomPedigreeNumber
                    bool correctMomPedigreeNumberInput = false;

                    while (correctMomPedigreeNumberInput == false)
                    {
                        Console.Write("Please enter pedigree number of the dog's mother: ");
                        string inputMomPedigreeNumber = Console.ReadLine();

                        if (Regex.IsMatch(inputMomPedigreeNumber, @"^[a-zA-Z0-9]+$")) // if there is no input to pedigreeNumber or in wrong format
                        {
                            dog.MomPedigreeNumber = inputMomPedigreeNumber;
                            correctMomPedigreeNumberInput = true;
                        }
                        else if (string.IsNullOrEmpty(inputMomPedigreeNumber)) //Will accept no input and continue to next property insertion
                        {
                            correctMomPedigreeNumberInput = true;
                        }
                        else
                        {
                            Console.WriteLine("The entered input is not in the proper format (only letters and digits - no spaces or special characters).");
                        }
                    }
                    //DadPedigreeNumber
                    bool correctDadPedigreeNumberInput = false;

                    while (correctDadPedigreeNumberInput == false)
                    {
                        Console.Write("Please enter pedigree number of the dog's father: ");
                        string inputDadPedigreeNumber = Console.ReadLine();

                        if (Regex.IsMatch(inputDadPedigreeNumber, @"^[a-zA-Z0-9]+$")) // if there is no input to pedigreeNumber or in wrong format
                        {
                            dog.DadPedigreeNumber = inputDadPedigreeNumber;
                            correctDadPedigreeNumberInput = true;
                        }
                        else if (string.IsNullOrEmpty(inputDadPedigreeNumber)) //Will accept no input and continue to next property insertion
                        {
                            correctDadPedigreeNumberInput = true;
                        }
                        else
                        {
                            Console.WriteLine("The entered input is not in the proper format (only letters and digits - no spaces or special characters).");
                        }
                    }

                    //Owner
                    Console.Write("Please enter name of the dog's owner: ");
                    dog.Owner = Console.ReadLine();

                    //Breeder
                    Console.Write("Please enter name of the dog's breeder: ");
                    dog.Breeder = Console.ReadLine();

                    // add dog with the above info to the database
                    bool dogCreated = dogController.CreateDog(dog);

                    if (dogCreated)
                    {
                      // show resume of dog 
                      Console.Clear();
                      Console.WriteLine("RESUME OF REGISTERED DOG");
                      Console.WriteLine();
                      showProfileDogView.ShowView(dog);
                      Console.WriteLine();
                      Console.WriteLine("Press any key to return to register dog.");
                      Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        DogExist(pedigreeNumber);
                    }
                }
                else // a dog with the selected pedigreeNumber was found in our database
                {
                    DogExist(pedigreeNumber);
                }
            }

            void DogExist(string pedigreeNumber)
            {
                Console.WriteLine("Dog already exist.");
                Console.WriteLine();
                Dog existingDog = dogController.GetDog(pedigreeNumber);
                showProfileDogView.ShowView(existingDog);
                Console.WriteLine();
                Console.WriteLine("Press any key to return to register dog.");
                Console.ReadKey();
            }
        }
    }
}

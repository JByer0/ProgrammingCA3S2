using System.IO.Compression;
/*Name: Joe Byer
 *Student No: S00240739
 *Student Email: S00240739@atu.ie
 *Github link: https://github.com/JByer0/ProgrammingCA3S2
 *Date: 22/04/23
 *Desc: A file that reads in values abd names from a csv file
 * Finds Names,ages and occupations of passengers on ships in the file
 */
namespace pca3new
{
    internal class Program
    {
        public static int amountOfPassengers = 0;
        public static int passengerCount = 0;
        static void Main(string[] args)
        {
            shipfile[] mainShipFile;
            shipfile[] shipFileRead;
            mainShipFile = readShip();

            int type = 0;
            try
            {



                do
                {

                    Console.WriteLine("Type \n 1.Ship Report\n 2.Occupation Report \n 3.Age Report \n 4.Exit");
                    type = int.Parse(Console.ReadLine());

                    if (type == 1)
                    {
                        string entry = "";
                        Console.Write("Enter the ship that you want to check: ");
                        entry = Console.ReadLine();

                        //find name of ship in file
                        shipFileRead = names(mainShipFile, entry);



                    }
                    else if (type == 2)
                    {
                        //occupation check
                        occupation(mainShipFile);
                    }
                    else if (type == 3)
                    {
                        //age check
                        age(mainShipFile);
                    }
                    else if (type == 4)
                    {
                        //exit 
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number entered please try again or press 4 to exit");
                    }

                }
                while (type != 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"This program crashed because {ex.Message}");
            }




        }
        // this method reads the ship data from a CSV file and returns an array of shipfile objects
        static shipfile[] readShip()
        {
            shipfile[] myShipFile = new shipfile[500]; 

            
            FileStream fs = new FileStream("faminefiletoanalyse.csv", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string recordIn = sr.ReadLine(); // read the first line of the file (headers)

            string[] fields = new string[9]; 

            int i = 0; 

            sr.ReadLine(); // skip the second line of the file (unnecessary information)

            // read each line of the file and create a new shipfile object for each passenger
            while (recordIn != null)
            {
                // split the line into its fields
                fields = recordIn.Split(','); 
                shipfile passenger = new shipfile(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], fields[9]); // create a new shipfile object with the passenger's data
                // add the passenger's data to the shipfile array
                myShipFile[i] = passenger; 
                i++; 

                recordIn = sr.ReadLine(); 
            }

            sr.Close(); 

            amountOfPassengers = i; 

            shipfile[] nonEmptyShipFile = new shipfile[i]; 

            // copy the non-empty elements of the shipfile array to the new array
            for (int j = 0; j < i; j++)
            {
                nonEmptyShipFile[j] = myShipFile[j];
            }

            return nonEmptyShipFile; 
        }
        static shipfile[] names(shipfile[] mainShipFile, string shipName)
        {
            shipfile[] tempShip = new shipfile[amountOfPassengers];

            // this prints out the top header of the selected ship and converts inputs to uppercase 
            switch (shipName.ToUpper())
            {
                case "CLARE 187 06-06-1849 123":
                    Console.WriteLine("");
                    Console.WriteLine($"{mainShipFile[177].ManifestNum} leaving from {mainShipFile[177].PassengerPort} Arrived:{mainShipFile[177].Date} with 123 Passengers");
                    Console.WriteLine("");
                    break;
                case "MARY HARRINGTON 187 07-06-1848 102":
                    Console.WriteLine("");
                    Console.WriteLine($"{mainShipFile[32].ManifestNum} leaving from {mainShipFile[32].PassengerPort} Arrived:{mainShipFile[32].Date} with 102 Passengers");
                    Console.WriteLine("");
                    break;
                case "LINCOLN 187 02-05-1849 071":
                    Console.WriteLine("");
                    Console.WriteLine($"{mainShipFile[125].ManifestNum} leaving from {mainShipFile[125].PassengerPort} Arrived:{mainShipFile[125].Date} with 71 Passengers");
                    Console.WriteLine("");
                    break;
                case "DISPATCH 187 06-26-1851 049":
                    Console.WriteLine("");
                    Console.WriteLine($"{mainShipFile[315].ManifestNum} leaving from {mainShipFile[315].PassengerPort} Arrived:{mainShipFile[315].Date} with 49 Passengers");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Incorrect ship name entered.");
                    break;
            }


            // Loop through each passenger in the mainShipFile array and print them out
            for (int k = 0; k < amountOfPassengers; k++)
            {
                if (mainShipFile[k].ManifestNum == shipName)
                {

                    tempShip[k] = mainShipFile[k];//takes the specific ship's list


                    Console.WriteLine($"First Name {tempShip[k].PassengerFirstName} : Last Name {tempShip[k].PassengerSurname}");
                    Console.WriteLine("");

                    passengerCount = k;
                }
            }
            return tempShip;
        }

        static void occupation(shipfile[] mainShipFiles)
        {
            int spinsters = 0;
            int labourer = 0;
            int immigrant = 0;
            int cultivator = 0;
            int matron = 0;
            int dressmaker = 0;
            int child = 0;
            int fisherman = 0;
            int maid = 0;
            int smith = 0;
            int baker = 0;
            int none = 0;
            int tanner = 0;
            int infant = 0;
            int carperenter = 0;
            int driver = 0;
            int student = 0;
            int clerk = 0;
            int na = 0;
            int saddler = 0;
            int unknown = 0;

            int counter = 0;

            //count the occupations in the file
            for (int k = 0; k < amountOfPassengers; k++)
            {
                switch (mainShipFiles[k].Occupation)
                {
                    case "Spinster":
                        spinsters = spinsters + 1;
                        break;
                    case "Laborer (Ital. 'operaia') or Workman/Woman":
                        labourer = labourer + 1;
                        break;
                    case "Immigrant":
                        immigrant = immigrant + 1;
                        break;
                    case "Cultivator or Farmer":
                        cultivator = cultivator + 1;
                        break;
                    case "Matron":
                        matron = matron + 1;
                        break;
                    case "Dressmaker":
                        dressmaker = dressmaker + 1;
                        break;
                    case "Child":
                        child = child + 1;
                        break;
                    case "Fisher Man":
                        fisherman = fisherman + 1;
                        break;
                    case "Chamber Maid or Maid or Servant":
                        maid = maid + 1;
                        break;
                    case "Smith":
                        smith = smith + 1;
                        break;
                    case "Baker or Macaroni Maker":
                        baker = baker + 1;
                        break;
                    case "None":
                        none = none + 1;
                        break;
                    case "Tanner or Gerber":
                        tanner = tanner + 1;
                        break;
                    case "Infant":
                        infant = infant + 1;
                        break;
                    case "Carpenter":
                        carperenter = carperenter + 1;
                        break;
                    case "Coachman/Coach Driver or Driver":
                        driver = driver + 1;
                        break;
                    case "Student":
                        student = student + 1;
                        break;
                    case "Clerk":
                        clerk = clerk + 1;
                        break;
                    case "Undefined Code":
                        na = na + 1;
                        break;
                    case "Saddler":
                        saddler = saddler + 1;
                        break;
                    default:
                        unknown = unknown + 1;
                        break;
                }
                counter++;
            }

            //print each job 
            Console.WriteLine("");
            Console.WriteLine("Occupation   Amount");
            Console.WriteLine("");
            Console.WriteLine($"Spinsters:{spinsters}");
            Console.WriteLine($"Labourers:{labourer}");
            Console.WriteLine($"Immigrant:{immigrant}");
            Console.WriteLine($"Farmer:{cultivator}");
            Console.WriteLine($"Matron:{matron}");
            Console.WriteLine($"Dressmakers:{dressmaker}");
            Console.WriteLine($"Fisherman:{fisherman}");
            Console.WriteLine($"Maid:{maid}");
            Console.WriteLine($"Baker:{baker}");
            Console.WriteLine($"Tanner:{tanner}");
            Console.WriteLine($"Carpenter:{carperenter}");
            Console.WriteLine($"Driver:{driver}");
            Console.WriteLine($"Student:{student}");
            Console.WriteLine($"Clerk:{clerk}");
            Console.WriteLine($"Saddler:{saddler}");
            Console.WriteLine($"Undefined:{unknown}");
            Console.WriteLine($"None:{none}");
            Console.WriteLine($"Unknown:{unknown}");
            Console.WriteLine($"Infant:{infant}");
            Console.WriteLine($"Child:{child}");
            Console.WriteLine("");





        }
        static void age(shipfile[] mainShipFiles)
        {


            // initialise counters for each age group
            int infants = 0;
            int children = 0;
            int teen = 0;
            int youngAdult = 0;
            int adult = 0;
            int olderAdult = 0;
            int unknown = 0;

            try
            {
                // loop through each passenger to determine age group
                for (int k = 1; k < amountOfPassengers; k++)
                {
                    // split the age string into an array
                    string[] age = new string[amountOfPassengers];
                    age = mainShipFiles[k].Age.Split(' ');

                    // check the first element of the age array to determine age group
                    if (age[0] == "Infant")
                    {
                        infants++;
                    }
                    else if (age[0] == "Unknown")
                    {
                        unknown++;
                    }
                    else if (age[0] == "age")
                    {
                        // convert the second element of the age array to an integer
                        int age2 = int.Parse(age[1]);

                        // increment the appropriate age group counter
                        if (age2 <= 0)
                        {
                            infants++;
                        }
                        else if (age2 > 0 && age2 <= 12)
                        {
                            children++;
                        }
                        else if (age2 > 12 && age2 <= 19)
                        {
                            teen++;
                        }
                        else if (age2 > 19 && age2 <= 29)
                        {
                            youngAdult++;
                        }
                        else if (age2 >= 30 && age2 < 50)
                        {
                            adult++;
                        }
                        else if (age2 >= 50)
                        {
                            olderAdult++;
                        }
                        else
                        {
                            unknown++;
                        }
                    }
                }

                // print the count for each age group
                Console.WriteLine("");
                Console.WriteLine("Age Group      Amount");
                Console.WriteLine("");
                Console.WriteLine($"Infants <0 : {infants}");
                Console.WriteLine($"Children 1-12  : {children}");
                Console.WriteLine($"Teenagers 13-19  : {teen}");
                Console.WriteLine($"Young Adults 20-29  : {youngAdult}");
                Console.WriteLine($"Adults 30+ : {adult}");
                Console.WriteLine($"Older Adult 50+  : {olderAdult}");
                Console.WriteLine($"Unknown  : {unknown}");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                // catch any errors that occur and print the error message
                Console.WriteLine($"This program crashed because {e.Message}");
            }


        }
    }

}

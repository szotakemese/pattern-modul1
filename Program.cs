using System;
 
namespace Modul1
{
    class MainApp
    {
    
        static void Main()
        {
        // Facade

            Sender sender = new Sender("SENDER", 15032.25);
            Receiver receiver = new Receiver("RECEIVER", 20.74);
            Parcel parcel = new Parcel("PARCEL", 250);
            
            Console.WriteLine("___________________SERVICES____________________");
            Console.WriteLine(" 1. Accept the parcel from " + sender.Name);
            Console.WriteLine(" 2. Buy " + parcel.Name + " in shop");
            Console.WriteLine(" 3. Pack the " + parcel.Name);
            Console.WriteLine(" 4. Write the details of the " + sender.Name + " to " + parcel.Name);
            Console.WriteLine(" 5. Deliver the " + parcel.Name);
            Console.WriteLine(" 6. Accept payment from the " + receiver.Name + "for delivery ");
            Console.WriteLine(" 7. Accept payment from the " + receiver.Name + "for the invoice ");
            Console.WriteLine(" 8. Accept payment from " + sender.Name);
            
            AnonymousGift anGift = new AnonymousGift();
            bool anGiftOptional = anGift.IsOptional(sender.Balance, parcel.Price);
            Console.WriteLine(" Anonymous Gift is " + (anGiftOptional ? "optional" : "not avaliable"));
            if(anGiftOptional){
                Console.WriteLine("__________ANONYMOUS GIFT SENDING STEPS__________");
                Console.WriteLine(" Accept payment from the anonymous sender");
                Console.WriteLine(" Buy " + parcel.Name + " in shop");
                Console.WriteLine(" Pack the " + parcel.Name);
                Console.WriteLine(" Deliver to the " + receiver.Name);
            }

            OnlineAuction onAuct = new OnlineAuction();
            bool onAuctOptional = onAuct.IsOptional(receiver.Balance, parcel.Price);
            Console.WriteLine(" Delivery from the online auction is " + (onAuctOptional ? "optional" : "not avaliable"));
            if(onAuctOptional){
                Console.WriteLine("_____DELIVERY FROM THE ONLINE AUCTION STEPS_____");
                Console.WriteLine(" Accept the parcel");
                Console.WriteLine(" Pack the " + parcel.Name);
                Console.WriteLine(" Write the details to " + parcel.Name);
                Console.WriteLine(" Deliver the  " + parcel.Name);
                Console.WriteLine(" Accept payment from the" + receiver.Name + "for the invoice ");
            }


            Console.ReadKey();
        }
    }

    class Sender
    {
        private string _name;
        private double _balance;
        public Sender(string name, double balance)
        {
            this._name = name;
            this._balance = balance;
        }

        public string Name
        {
            get { return _name; }
        }

        public double Balance
        {
            get {return _balance;}
        }
    }

    class Receiver
    {
        private string _name;
        private double _balance;
        public Receiver(string name, double balance)
        {
            this._name = name;
            this._balance = balance;
        }

        public string Name
        {
            get { return _name; }
        }

        public double Balance
        {
            get {return _balance;}
        }
    }
    class Parcel
    {
        private string _name;
        private double _price;
        public Parcel(string name, double price)
        {
            this._name = name;
            this._price = price;
        }

        public string Name
        {
            get { return _name;}
        }

        public double Price
        {
            get{ return _price;}
        }
    }

    class AnonymousGift
    {
        private double deliveryPrice(double pPrice){
            var deliveryPrice = pPrice * 0.2;
            return deliveryPrice;
        }
        public bool IsOptional(double sBalance, double pPrice)
        {
            Console.WriteLine("\n Checking anonymous gift");
            Console.WriteLine("________________________________________________");
            bool optional = true;
            string message = "";

            if(sBalance < (pPrice+deliveryPrice(pPrice))){
                optional = false;
                message = " Not enough money on the sender's balance";
                Console.WriteLine(message);
            }
 
        return optional;
        }
    }

    class OnlineAuction
    {   
        private double deliveryPrice(double pPrice){
            var deliveryPrice = pPrice * 0.2;
            return deliveryPrice;
        }
        public bool IsOptional( double rBalance, double pPrice)
        {
            Console.WriteLine("\n Checking delivery from the online auction");
            Console.WriteLine("________________________________________________");
            bool optional = true;
            string message = "";

            if(rBalance < deliveryPrice(pPrice)){
                optional = false;
                message = " Not enough money on the receiver's balance";
                Console.WriteLine(message);
            }
 
        return optional;
        }
    }
}


using System;
using System.Collections.Generic;

class BankAccount
{
    public int AccountID { get; }
    public decimal BalanceAmount { get; set; }

    public BankAccount(int accountID, decimal initialBalance)
    {
        AccountID = accountID;
        BalanceAmount = initialBalance;
    }

    public void AddFunds(decimal amount)
    {
        BalanceAmount += amount;
    }

    public void WithdrawFunds(decimal amount)
    {
        if (BalanceAmount >= amount)
        {
            BalanceAmount -= amount;
        }
        else
        {
            Console.WriteLine("Недостаточно средств.");
        }
    }

    public void CloseAccount()
    {
        BalanceAmount = 0;
    }
}

class CreditCard
{
    public int CardID { get; }
    public decimal CreditLimitAmount { get; set; }
    public bool IsCardBlocked { get; set; }

    public CreditCard(int cardID, decimal creditLimit)
    {
        CardID = cardID;
        CreditLimitAmount = creditLimit;
        IsCardBlocked = false;
    }

    public void BlockCard()
    {
        IsCardBlocked = true;
    }
}

class Order
{
    public int OrderID { get; }
    public decimal Price { get; set; }

    public Order(int orderID, decimal price)
    {
        OrderID = orderID;
        Price = price;
    }
}

class Customer
{
    public string FullName { get; set; }
    public BankAccount CustomerAccount { get; set; }
    public CreditCard CustomerCard { get; set; }

    public Customer(string fullName, decimal initialBalance, decimal creditLimit)
    {
        FullName = fullName;
        CustomerAccount = new BankAccount(GetNextAccountID(), initialBalance);
        CustomerCard = new CreditCard(GetNextCardID(), creditLimit);
    }

    private static int accountIDCounter = 1;
    private static int cardIDCounter = 1;

    private int GetNextAccountID()
    {
        return accountIDCounter++;
    }

    private int GetNextCardID()
    {
        return cardIDCounter++;
    }

    public void MakePurchase(Order order)
    {
        if (!CustomerCard.IsCardBlocked)
        {
            if (CustomerAccount.BalanceAmount >= order.Price)
            {
                CustomerAccount.WithdrawFunds(order.Price);
            }
            else if (CustomerCard.CreditLimitAmount >= order.Price)
            {
                CustomerCard.CreditLimitAmount -= order.Price;
            }
            else
            {
                Console.WriteLine("Платеж не удался: Недостаточно средств и превышен кредитный лимит.");
            }
        }
        else
        {
            Console.WriteLine("Платеж не удался: Карта заблокирована.");
        }
    }

    public void SendMoney(decimal amount, BankAccount targetAccount)
    {
        if (CustomerAccount.BalanceAmount >= amount)
        {
            CustomerAccount.WithdrawFunds(amount);
            targetAccount.AddFunds(amount);
        }
        else
        {
            Console.WriteLine("Перевод не удался: Недостаточно средств.");
        }
    }
}

class Manager
{
    public void BlockCustomerCard(Customer customer)
    {
        if (customer.CustomerCard != null)
        {
            customer.CustomerCard.BlockCard();
        }
    }
}

class PaymentSystem
{
    static void Main()
    {
        Customer customer1 = new Customer("Иванов Иван", 1000, 500);
        Customer customer2 = new Customer("Петров Петр", 2000, 1000);

        Manager manager = new Manager();

        Order order1 = new Order(1, 300);
        Order order2 = new Order(2, 1500);

        customer1.MakePurchase(order1);
        customer1.MakePurchase(order2);

        Console.WriteLine($"Клиент: {customer1.FullName}, Баланс счета в банке: {customer1.CustomerAccount.BalanceAmount:C}, Кредитный лимит карты: {customer1.CustomerCard.CreditLimitAmount:C}");

        customer2.SendMoney(500, customer1.CustomerAccount);

        Console.WriteLine($"Клиент: {customer1.FullName}, Баланс счета в банке: {customer1.CustomerAccount.BalanceAmount:C}");
        Console.WriteLine($"Клиент: {customer2.FullName}, Баланс счета в банке: {customer2.CustomerAccount.BalanceAmount:C}");

        manager.BlockCustomerCard(customer1);

        customer1.MakePurchase(order2);

        Console.WriteLine($"Клиент: {customer1.FullName}, Карта заблокирована: {customer1.CustomerCard.IsCardBlocked}");

        Console.ReadLine();
    }
}

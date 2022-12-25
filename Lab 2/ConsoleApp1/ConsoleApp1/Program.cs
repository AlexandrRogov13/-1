global using static System.Console;
using System.Net.Mime;
using System.IO;
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System;

using (DataBase db = new DataBase())
{
    for (; ; )
    {
        WriteLine("Доступные варианты действий:");
        WriteLine("1 - 6");
        
        WriteLine();
        Write("Выбор варианта: ");
        string? action = ReadLine();
        WriteLine();
        if (action == "0") break;
        int num = 0;

        switch (action)
        {

            case "1":
                WriteLine("Найти на всех складах машину марки Alfa Romeo что имеются на складе (IsStock)");
                var z1 = db.Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock).ToList();
                foreach (var p in z1)
                {
                    WriteLine($" Машина:{p.Name} Цена:{p.Cost}");
                }
                break;

            case "2":
                WriteLine();
                WriteLine("Вывести все склады где есть машина BMW");
                var z2 = db.Cars.Where(p => p.Name.Contains("BMW")).Select(p => p.Stock).Distinct().ToList();
                foreach (var p in z2)
                {
                    WriteLine($" Склад:{p.City}");
                }
                break;

            case "3":
                WriteLine();
                WriteLine("Найти все машины которые стоят меньше 10000 $");
                var z3 = db.Cars.Where(p => p.Cost < 10000).ToList();
                foreach (var p in z3)
                {
                    WriteLine($" Машина:{p.Name} Цена:{p.Cost} $");
                }
                break;
            case "4":
                WriteLine();
                WriteLine("Найти все машины с пометками для продажи (remark) и отсортировать по имени");
                var z4 = db.Cars.Where(p => p.Remark != "").ToList();
                foreach (var p in z4)
                {
                    WriteLine($" Машина:{p.Name} Пометка для продажи:{p.Remark}");
                }
                break;

            case "5":
                WriteLine();
                WriteLine("Вывести все склады на которых есть машины с годом выпуска с 2000 до 2005 и отсортировать их по количеству машин на складе (сначала где их много)");
                var z5 = db.Cars.Where(p => p.DataRelease >= 2000 && p.DataRelease <= 2005).GroupBy(p => p.Stock.City).Select(p => new { Name = p.Key, Count = p.Count() }).OrderByDescending(p => p.Count).ToList();
                foreach (var p in z5)
                {
                    WriteLine($" Склад: {p.Name}  количество машин: {p.Count}");
                }
                break;

            case "6":
                WriteLine();
                WriteLine("Вывести все машины выпущенные до 2000 года и отсортировать по году выпуска");
                var z6 = db.Cars.Where(p => p.DataRelease < 2000).OrderByDescending(p => p.DataRelease).ToList();
                foreach (var p in z6)
                {
                    WriteLine($" Машина {p.Name} {p.DataRelease} года");
                }
                break;

            default:
                WriteLine("неверный ввод");
                break;

        }

    }
    //-----------------------------------
   
    //-----------------------------------
   
    //-----------------------------------
    
    //------------------------------------
   
    //------------------------------------
   
    //-----------------------------------
    
    //--Вызов метода
    Report rep = new Report() { database = db };
    rep.WriteAllReport();
    //---------------
}
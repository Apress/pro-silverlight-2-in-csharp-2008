﻿using System;
using System.ComponentModel;
using System.Runtime.Serialization;

[DataContract()]
public class Product : INotifyPropertyChanged
{
    private bool hasChanges = false;
    public bool HasChanges
    {
        get { return hasChanges; }
        set { hasChanges = value; }
    }

    private string modelNumber;
    [DataMember()]
    public string ModelNumber
    {
        get { return modelNumber; }
        set
        {
            modelNumber = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ModelNumber"));
        }
    }

    private string modelName;
    [DataMember()]
    public string ModelName
    {
        get { return modelName; }
        set
        {
            modelName = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ModelName"));
        }
    }

    private double unitCost;
    [DataMember()]
    public double UnitCost
    {
        get { return unitCost; }
        set
        {
            unitCost = value;
            OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
        }
    }

    private string description;
    [DataMember()]
    public string Description
    {
        get { return description; }
        set
        {
            description = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Description"));
        }
    }

    private string categoryName;
    [DataMember()]
    public string CategoryName
    {
        get { return categoryName; }
        set { categoryName = value; }
    }

    private string productImagePath;
    [DataMember()]
    public string ProductImagePath
    {
        get { return productImagePath; }
        set { productImagePath = value; }
    }

    public Product(string modelNumber, string modelName,
        double unitCost, string description)
    {
        ModelNumber = modelNumber;
        ModelName = modelName;
        UnitCost = unitCost;
        Description = description;
    }

    public Product(string modelNumber, string modelName,
       double unitCost, string description,
       string productImagePath)
        :
       this(modelNumber, modelName, unitCost, description)
    {
        ProductImagePath = productImagePath;
    }

    public Product(string modelNumber, string modelName,
        double unitCost, string description, string categoryName,
        string productImagePath) :
        this(modelNumber, modelName, unitCost, description)
    {
        CategoryName = categoryName;
        ProductImagePath = productImagePath;
    }

    public Product() { }

    public override string ToString()
    {
        return ModelName + " (" + ModelNumber + ")";
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, e);
    }
}


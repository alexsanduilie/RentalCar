﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalCarDesktop.ListCarsServiceReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ListCarsServiceReference.ListCarsServiceSoap")]
    public interface ListCarsServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/readAllInDataTable", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable readAllInDataTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/readAllInDataTable", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> readAllInDataTableAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/readAll", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        RentalCarDesktop.ListCarsServiceReference.Car[] readAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/readAll", ReplyAction="*")]
        System.Threading.Tasks.Task<RentalCarDesktop.ListCarsServiceReference.Car[]> readAllAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Car : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int carIDField;
        
        private string plateField;
        
        private string manufacturerField;
        
        private string modelField;
        
        private double priceField;
        
        private string locationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int carID {
            get {
                return this.carIDField;
            }
            set {
                this.carIDField = value;
                this.RaisePropertyChanged("carID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string plate {
            get {
                return this.plateField;
            }
            set {
                this.plateField = value;
                this.RaisePropertyChanged("plate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string manufacturer {
            get {
                return this.manufacturerField;
            }
            set {
                this.manufacturerField = value;
                this.RaisePropertyChanged("manufacturer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
                this.RaisePropertyChanged("price");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
                this.RaisePropertyChanged("location");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ListCarsServiceSoapChannel : RentalCarDesktop.ListCarsServiceReference.ListCarsServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ListCarsServiceSoapClient : System.ServiceModel.ClientBase<RentalCarDesktop.ListCarsServiceReference.ListCarsServiceSoap>, RentalCarDesktop.ListCarsServiceReference.ListCarsServiceSoap {
        
        public ListCarsServiceSoapClient() {
        }
        
        public ListCarsServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ListCarsServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ListCarsServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ListCarsServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public System.Data.DataTable readAllInDataTable() {
            return base.Channel.readAllInDataTable();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> readAllInDataTableAsync() {
            return base.Channel.readAllInDataTableAsync();
        }
        
        public RentalCarDesktop.ListCarsServiceReference.Car[] readAll() {
            return base.Channel.readAll();
        }
        
        public System.Threading.Tasks.Task<RentalCarDesktop.ListCarsServiceReference.Car[]> readAllAsync() {
            return base.Channel.readAllAsync();
        }
    }
}

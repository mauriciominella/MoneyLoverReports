﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("MoneyLoverPCDataModel", "categorytransaction", "category", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(MoneyLoverPC.Business.categories), "transaction", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(MoneyLoverPC.Business.transactions), true)]
[assembly: EdmRelationshipAttribute("MoneyLoverPCDataModel", "userstransactions", "users", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(MoneyLoverPC.Business.users), "transactions", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(MoneyLoverPC.Business.transactions), true)]

#endregion

namespace MoneyLoverPC.Business
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class MoneyLoverPCDataModelContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new MoneyLoverPCDataModelContainer object using the connection string found in the 'MoneyLoverPCDataModelContainer' section of the application configuration file.
        /// </summary>
        public MoneyLoverPCDataModelContainer() : base("name=MoneyLoverPCDataModelContainer", "MoneyLoverPCDataModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MoneyLoverPCDataModelContainer object.
        /// </summary>
        public MoneyLoverPCDataModelContainer(string connectionString) : base(connectionString, "MoneyLoverPCDataModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MoneyLoverPCDataModelContainer object.
        /// </summary>
        public MoneyLoverPCDataModelContainer(EntityConnection connection) : base(connection, "MoneyLoverPCDataModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<transactions> transactionsSet
        {
            get
            {
                if ((_transactionsSet == null))
                {
                    _transactionsSet = base.CreateObjectSet<transactions>("transactionsSet");
                }
                return _transactionsSet;
            }
        }
        private ObjectSet<transactions> _transactionsSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<categories> categoriesSet
        {
            get
            {
                if ((_categoriesSet == null))
                {
                    _categoriesSet = base.CreateObjectSet<categories>("categoriesSet");
                }
                return _categoriesSet;
            }
        }
        private ObjectSet<categories> _categoriesSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<users> usersSet
        {
            get
            {
                if ((_usersSet == null))
                {
                    _usersSet = base.CreateObjectSet<users>("usersSet");
                }
                return _usersSet;
            }
        }
        private ObjectSet<users> _usersSet;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the transactionsSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTotransactionsSet(transactions transactions)
        {
            base.AddObject("transactionsSet", transactions);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the categoriesSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTocategoriesSet(categories categories)
        {
            base.AddObject("categoriesSet", categories);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the usersSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTousersSet(users users)
        {
            base.AddObject("usersSet", users);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MoneyLoverPCDataModel", Name="categories")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class categories : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new categories object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="icon">Initial value of the icon property.</param>
        /// <param name="group_id">Initial value of the group_id property.</param>
        public static categories Createcategories(global::System.Int64 id, global::System.String name, global::System.String icon, global::System.Int32 group_id)
        {
            categories categories = new categories();
            categories.id = id;
            categories.name = name;
            categories.icon = icon;
            categories.group_id = group_id;
            return categories;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int64 _id;
        partial void OnidChanging(global::System.Int64 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String icon
        {
            get
            {
                return _icon;
            }
            set
            {
                OniconChanging(value);
                ReportPropertyChanging("icon");
                _icon = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("icon");
                OniconChanged();
            }
        }
        private global::System.String _icon;
        partial void OniconChanging(global::System.String value);
        partial void OniconChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 type
        {
            get
            {
                return _type;
            }
            set
            {
                OntypeChanging(value);
                ReportPropertyChanging("type");
                _type = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("type");
                OntypeChanged();
            }
        }
        private global::System.Int32 _type = 0;
        partial void OntypeChanging(global::System.Int32 value);
        partial void OntypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 group_id
        {
            get
            {
                return _group_id;
            }
            set
            {
                Ongroup_idChanging(value);
                ReportPropertyChanging("group_id");
                _group_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("group_id");
                Ongroup_idChanged();
            }
        }
        private global::System.Int32 _group_id;
        partial void Ongroup_idChanging(global::System.Int32 value);
        partial void Ongroup_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                Onuser_idChanging(value);
                ReportPropertyChanging("user_id");
                _user_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("user_id");
                Onuser_idChanged();
            }
        }
        private global::System.Int32 _user_id = 0;
        partial void Onuser_idChanging(global::System.Int32 value);
        partial void Onuser_idChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MoneyLoverPCDataModel", Name="transactions")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class transactions : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new transactions object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="amount">Initial value of the amount property.</param>
        /// <param name="type">Initial value of the type property.</param>
        /// <param name="created_date">Initial value of the created_date property.</param>
        /// <param name="displayed_date">Initial value of the displayed_date property.</param>
        /// <param name="cat_id">Initial value of the cat_id property.</param>
        /// <param name="status">Initial value of the status property.</param>
        /// <param name="user_id">Initial value of the user_id property.</param>
        public static transactions Createtransactions(global::System.Int64 id, global::System.Decimal amount, global::System.Int32 type, global::System.DateTime created_date, global::System.DateTime displayed_date, global::System.Int64 cat_id, global::System.Int32 status, global::System.Int64 user_id)
        {
            transactions transactions = new transactions();
            transactions.id = id;
            transactions.amount = amount;
            transactions.type = type;
            transactions.created_date = created_date;
            transactions.displayed_date = displayed_date;
            transactions.cat_id = cat_id;
            transactions.status = status;
            transactions.user_id = user_id;
            return transactions;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int64 _id;
        partial void OnidChanging(global::System.Int64 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal amount
        {
            get
            {
                return _amount;
            }
            set
            {
                OnamountChanging(value);
                ReportPropertyChanging("amount");
                _amount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("amount");
                OnamountChanged();
            }
        }
        private global::System.Decimal _amount;
        partial void OnamountChanging(global::System.Decimal value);
        partial void OnamountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 type
        {
            get
            {
                return _type;
            }
            set
            {
                OntypeChanging(value);
                ReportPropertyChanging("type");
                _type = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("type");
                OntypeChanged();
            }
        }
        private global::System.Int32 _type;
        partial void OntypeChanging(global::System.Int32 value);
        partial void OntypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime created_date
        {
            get
            {
                return _created_date;
            }
            set
            {
                Oncreated_dateChanging(value);
                ReportPropertyChanging("created_date");
                _created_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("created_date");
                Oncreated_dateChanged();
            }
        }
        private global::System.DateTime _created_date;
        partial void Oncreated_dateChanging(global::System.DateTime value);
        partial void Oncreated_dateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime displayed_date
        {
            get
            {
                return _displayed_date;
            }
            set
            {
                Ondisplayed_dateChanging(value);
                ReportPropertyChanging("displayed_date");
                _displayed_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("displayed_date");
                Ondisplayed_dateChanged();
            }
        }
        private global::System.DateTime _displayed_date;
        partial void Ondisplayed_dateChanging(global::System.DateTime value);
        partial void Ondisplayed_dateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 cat_id
        {
            get
            {
                return _cat_id;
            }
            set
            {
                Oncat_idChanging(value);
                ReportPropertyChanging("cat_id");
                _cat_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("cat_id");
                Oncat_idChanged();
            }
        }
        private global::System.Int64 _cat_id;
        partial void Oncat_idChanging(global::System.Int64 value);
        partial void Oncat_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String with_person
        {
            get
            {
                return _with_person;
            }
            set
            {
                Onwith_personChanging(value);
                ReportPropertyChanging("with_person");
                _with_person = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("with_person");
                Onwith_personChanged();
            }
        }
        private global::System.String _with_person;
        partial void Onwith_personChanging(global::System.String value);
        partial void Onwith_personChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> remind_date
        {
            get
            {
                return _remind_date;
            }
            set
            {
                Onremind_dateChanging(value);
                ReportPropertyChanging("remind_date");
                _remind_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("remind_date");
                Onremind_dateChanged();
            }
        }
        private Nullable<global::System.DateTime> _remind_date;
        partial void Onremind_dateChanging(Nullable<global::System.DateTime> value);
        partial void Onremind_dateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 remind_num
        {
            get
            {
                return _remind_num;
            }
            set
            {
                Onremind_numChanging(value);
                ReportPropertyChanging("remind_num");
                _remind_num = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("remind_num");
                Onremind_numChanged();
            }
        }
        private global::System.Int32 _remind_num = 0;
        partial void Onremind_numChanging(global::System.Int32 value);
        partial void Onremind_numChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String note
        {
            get
            {
                return _note;
            }
            set
            {
                OnnoteChanging(value);
                ReportPropertyChanging("note");
                _note = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("note");
                OnnoteChanged();
            }
        }
        private global::System.String _note;
        partial void OnnoteChanging(global::System.String value);
        partial void OnnoteChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 status
        {
            get
            {
                return _status;
            }
            set
            {
                OnstatusChanging(value);
                ReportPropertyChanging("status");
                _status = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("status");
                OnstatusChanged();
            }
        }
        private global::System.Int32 _status;
        partial void OnstatusChanging(global::System.Int32 value);
        partial void OnstatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                Onuser_idChanging(value);
                ReportPropertyChanging("user_id");
                _user_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("user_id");
                Onuser_idChanged();
            }
        }
        private global::System.Int64 _user_id;
        partial void Onuser_idChanging(global::System.Int64 value);
        partial void Onuser_idChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MoneyLoverPCDataModel", Name="users")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class users : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new users object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="icon">Initial value of the icon property.</param>
        public static users Createusers(global::System.Int64 id, global::System.String name, global::System.String icon)
        {
            users users = new users();
            users.id = id;
            users.name = name;
            users.icon = icon;
            return users;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int64 _id;
        partial void OnidChanging(global::System.Int64 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String icon
        {
            get
            {
                return _icon;
            }
            set
            {
                OniconChanging(value);
                ReportPropertyChanging("icon");
                _icon = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("icon");
                OniconChanged();
            }
        }
        private global::System.String _icon;
        partial void OniconChanging(global::System.String value);
        partial void OniconChanged();

        #endregion
    
    }

    #endregion
    
}

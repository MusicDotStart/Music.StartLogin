﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class audio
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public audio()
    {
        this.reactions = new HashSet<reaction1>();
    }

    public int id { get; set; }
    public string name { get; set; }
    public Nullable<int> genre { get; set; }
    public Nullable<int> demo { get; set; }
    public Nullable<int> owner { get; set; }
    public System.Guid guid { get; set; }
    public byte[] data { get; set; }

    public virtual genre genre1 { get; set; }
    public virtual user user { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<reaction1> reactions { get; set; }
}

public partial class genre
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public genre()
    {
        this.audios = new HashSet<audio>();
    }

    public int id { get; set; }
    public string genre1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<audio> audios { get; set; }
}

public partial class Organization
{
    public int id { get; set; }
    public string name { get; set; }
    public int genre { get; set; }
}

public partial class reaction
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public reaction()
    {
        this.reactions = new HashSet<reaction1>();
    }

    public int id { get; set; }
    public string reaction1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<reaction1> reactions { get; set; }
}

public partial class reaction1
{
    public int id { get; set; }
    public int who { get; set; }
    public int what { get; set; }
    public int how { get; set; }

    public virtual audio audio { get; set; }
    public virtual reaction reaction { get; set; }
    public virtual user user { get; set; }
}

public partial class sysdiagram
{
    public string name { get; set; }
    public int principal_id { get; set; }
    public int diagram_id { get; set; }
    public Nullable<int> version { get; set; }
    public byte[] definition { get; set; }
}

public partial class user
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public user()
    {
        this.audios = new HashSet<audio>();
        this.reactions = new HashSet<reaction1>();
    }

    public int uId { get; set; }
    public string uUserName { get; set; }
    public string uPassword { get; set; }
    public string uNameFirst { get; set; }
    public string uNameLast { get; set; }
    public string uType { get; set; }
    public string uNotifyMeAddress { get; set; }
    public Nullable<int> uVerifyCode { get; set; }
    public string uName { get; set; }
    public Nullable<int> uAssociation { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<audio> audios { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<reaction1> reactions { get; set; }
}

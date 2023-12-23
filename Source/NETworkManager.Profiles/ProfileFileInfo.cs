﻿using System;
using System.Security;
using NETworkManager.Utilities;

namespace NETworkManager.Profiles;

public class ProfileFileInfo : PropertyChangedBase
{
    /// <summary>
    ///     Private field for the <see cref="IsEncrypted" /> property.
    /// </summary>
    private bool _isEncrypted;

    /// <summary>
    ///     Private field for the <see cref="IsPasswordValid" /> property.
    /// </summary>
    private bool _isPasswordValid;

    /// <summary>
    ///     Private field for the <see cref="Name" /> property.
    /// </summary>
    private string _name;

    /// <summary>
    ///     Private field for the <see cref="Path" /> property.
    /// </summary>
    private string _path;

    /// <summary>
    ///     Profile file info contains all necessary information's about the profile file and location.
    /// </summary>
    /// <param name="name"><see cref="Name" /> of the profile file.</param>
    /// <param name="path"><see cref="Path" /> of the profile file.</param>
    /// <param name="isEncrypted"><see cref="IsEncrypted" /> indicates if the file is encrypted.</param>
    public ProfileFileInfo(string name, string path, bool isEncrypted = false)
    {
        ID = Guid.NewGuid();
        Name = name;
        Path = path;
        IsEncrypted = isEncrypted;
    }

    /// <summary>
    ///     Make object unique.
    /// </summary>
    private Guid ID { get; }

    /// <summary>
    ///     Name of the profile. This is the filename without extension.
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            if (value == _name)
                return;

            _name = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Full path of the profile file.
    /// </summary>
    public string Path
    {
        get => _path;
        set
        {
            if (value == _path)
                return;

            _path = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Indicates if the profile file is encrypted.
    /// </summary>
    public bool IsEncrypted
    {
        get => _isEncrypted;
        set
        {
            if (value == _isEncrypted)
                return;

            _isEncrypted = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Password to encrypt and decrypt the profile file.
    /// </summary>
    public SecureString Password { get; set; }

    /// <summary>
    ///     Indicates if the password is valid and can be used for encryption or decryption.
    /// </summary>
    public bool IsPasswordValid
    {
        get => _isPasswordValid;
        set
        {
            if (value == _isPasswordValid)
                return;

            _isPasswordValid = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Overrides the default <see cref="Equals(object)" /> method.
    /// </summary>
    /// <param name="obj">Object from type <see cref="ProfileFileInfo" />.</param>
    /// <returns>Returns true if the <see cref="ProfileFileInfo" /> is equal to another <see cref="ProfileFileInfo" />.</returns>
    public override bool Equals(object obj)
    {
        if (obj is not ProfileFileInfo info)
            return false;

        return info.ID == ID;
    }

    /// <summary>
    ///     Overrides the default GetHashCode() method.
    /// </summary>
    /// <returns>Return the hashcode generated by the path of the <see cref="ProfileFileInfo" />.</returns>
    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}
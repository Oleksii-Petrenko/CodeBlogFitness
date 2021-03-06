﻿using System;
using System.Runtime.CompilerServices;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        #region Свойства.
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рожления.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weigth { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Heigth { get; set; }

        /// <summary>
        /// как опреденить коректний воззраст человека ....
        ///     DateTime nowDate = DateTime.Today;
        ///     int age = nowDate.Year - birthDate.Year;
        ///      if (birthDate > nowDate.AddYers(-age)) age--;
        /// </summary>


        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }


        #endregion



        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weigth">Вес.</param>
        /// <param name="heigth">Рост.</param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weigth,
                    double heigth)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустим или null.", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустим или null.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }
            if (weigth <= 0)
            {
                throw new ArgumentException("Вес не может быть пустим или null.", nameof(weigth));
            }
            if (heigth <= 0)
            {
                throw new ArgumentException("Рост не может быть пустим или null.", nameof(heigth));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weigth = weigth;
            Heigth = heigth;

        }

        public User()
        {
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустим или null.", nameof(name));
            }

            Name = name;

        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}

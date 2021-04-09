using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string CarAdded = "Araç Eklendi";
		public static string CarNameInvalid = "Araba ismi geçersiz";
		internal static string MaintenanceTime = "Sistem bakımda";
		internal static string CarsListed = "Araçlar listelendi";
		internal static string CarDeleted = "Araç Silindi";
		internal static string CarUpdated = "Araç güncellendi";
		internal static string BrandAdded;
		internal static string BrandDeleted;
		internal static string BrandUpdated;
		internal static string BrandListed;
		internal static string ColorAdded = "Araç Rengi eklendi";
		internal static string ColorDeleted;
		internal static string ColorUpdated;
		internal static string ColorListed;
		internal static string CustomerAdded;
		internal static string CustomerDeleted;
		internal static string CustomerUpdated;
		internal static string RentalAdded;
		internal static string RentalUpdated;
		internal static string RentalDeleted;
		internal static string RentalUndeliveredCar;
		internal static string RentalNotAvailable;
		internal static string UserAdded;
		internal static string UserDeleted;
		public static string UserUpdated = "Kullanıcı Güncellendi";
		internal static string CustomerNotAdded;
		internal static string CarImageCountOfCarError;
		internal static string CarImageDeleted;
		internal static string CarImageUpdated;
		internal static string CarImageAdded;
		internal static string AuthorizationDenied = "Yetkiniz yok";
		internal static string OperationClaimAdded;
		internal static string OperationClaimUpdated;
		internal static string OperationClaimDeleted;
		internal static string UserOperationClaimAdded;
		internal static string UserOperationClaimUpdated;
		internal static string UserOperationClaimDeleted;
		internal static string UserRegistered = "Kullanıcı eklendi";
		internal static string UserNotFound = "Kullanıcı bulunamadı";
		internal static string PasswordError = "Parola Hatası";
		internal static string SuccessfullLogin = "Başarıyla giriş yapıldı";
		internal static string AccessTokenCreated = "AccessToken Created";
		internal static string UserAlreadyExists = "Kullanıcı sistemde mevcut";
		internal static string SuccessfulLogin;
	}
}

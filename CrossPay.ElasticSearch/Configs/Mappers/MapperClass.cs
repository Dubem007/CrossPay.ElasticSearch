using AutoMapper.Internal;
using CrossPay.ElasticSearch.Entities;
using CrossPay.ElasticSearch.Entities.Documents;
using CrossPay.ElasticSearch.Entities.Dtos;
using CrossPay.ElasticSearch.Entities.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Configs.Mappers
{
    public static class MapperClass
    {
        public static SuccessfulTransactionDocument Map(this WalletTransactions model)
        {
            if (model == null)
                return null;

            return new SuccessfulTransactionDocument
            {
                Id = model.Id,
                UserId = model.UserId,
                WalletId = model.WalletId,
                SourceAccount = model.SourceAccount,
                SourceAccountName = model.SourceAccountName,
                SourceCurrency = model.SourceCurrency,
                DestinationAccount = model.DestinationAccount,
                DestinationAccountName = model.DestinationAccountName,
                DestinationInstitutionName = model.DestinationInstitutionName,
                DestinationCurrency = model.DestinationCurrency,
                Amount = model.Amount,
                Currency = model.Currency,
                Narration = model.Narration,
                TransactionStatus = model.TransactionStatus,
                TransactionStatusDescription = model.TransactionStatusDescription,
                TransactionDate = model.TransactionDate,
                DestinationBankCode = model.DestinationBankCode,
                DestinationBankName = model.DestinationBankName,
                TransactionType = model.TransactionType,
                OperationType = model.OperationType,
                Provider = model.Provider,
                DebitAmount = model.DebitAmount,
                DebitCurrency = model.DebitCurrency,
                CreditAmount = model.CreditAmount,
                CreditCurrency = model.CreditCurrency,
            };
        }

        public static FailedTransactionDocument MapFailed(this WalletTransactions model)
        {
            if (model == null)
                return null;

            return new FailedTransactionDocument
            {
                Id = model.Id,
                UserId = model.UserId,
                WalletId = model.WalletId,
                SourceAccount = model.SourceAccount,
                SourceAccountName = model.SourceAccountName,
                SourceCurrency = model.SourceCurrency,
                DestinationAccount = model.DestinationAccount,
                DestinationAccountName = model.DestinationAccountName,
                DestinationInstitutionName = model.DestinationInstitutionName,
                DestinationCurrency = model.DestinationCurrency,
                Amount = model.Amount,
                Currency = model.Currency,
                Narration = model.Narration,
                TransactionStatus = model.TransactionStatus,
                TransactionStatusDescription = model.TransactionStatusDescription,
                TransactionDate = model.TransactionDate,
                DestinationBankCode = model.DestinationBankCode,
                DestinationBankName = model.DestinationBankName,
                TransactionType = model.TransactionType,
                OperationType = model.OperationType,
                Provider = model.Provider,
                DebitAmount = model.DebitAmount,
                DebitCurrency = model.DebitCurrency,
                CreditAmount = model.CreditAmount,
                CreditCurrency = model.CreditCurrency,
            };
        }

        public static ActiveUserProfileIndex MapActiveUsers(this UserProfile model)
        {
            if (model == null)
                return null;

            return new ActiveUserProfileIndex
            {
                Id = model.Id,
                SSOUserId = model.SSOUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                State = model.State,
                CountryCode = model.CountryCode,
                CountryName = model.CountryName,
                IsDeleted = model.IsDeleted,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate,
                RecordStatus = model.RecordStatus,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy
            };
        }

        public static UserProfileDocument MapAllUsersProfiles(this UserProfile model)
        {
            if (model == null)
                return null;

            return new UserProfileDocument
            {
                Id = model.Id,
                SSOUserId = model.SSOUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                State = model.State,
                CountryCode = model.CountryCode,
                CountryName = model.CountryName,
                IsDeleted = model.IsDeleted,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate,
                RecordStatus = model.RecordStatus,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy
            };
        }


        public static ActiveUserProfileDocument MapActiveUsersProfiles(this UserProfile model)
        {
            if (model == null)
                return null;

            return new ActiveUserProfileDocument
            {
                Id = model.Id,
                SSOUserId = model.SSOUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                State = model.State,
                CountryCode = model.CountryCode,
                CountryName = model.CountryName,
                IsDeleted = model.IsDeleted,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate,
                RecordStatus = model.RecordStatus,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy
            };
        }

        public static InActiveUserProfileDocument MapInActiveUsersProfiles(this UserProfile model)
        {
            if (model == null)
                return null;

            return new InActiveUserProfileDocument
            {
                Id = model.Id,
                SSOUserId = model.SSOUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                State = model.State,
                CountryCode = model.CountryCode,
                CountryName = model.CountryName,
                IsDeleted = model.IsDeleted,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate,
                RecordStatus = model.RecordStatus,
                CreatedBy = model.CreatedBy,
                ModifiedBy = model.ModifiedBy
            };
        }


    }
}

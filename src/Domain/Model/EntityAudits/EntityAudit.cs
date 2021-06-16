using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using LiloDash.Domain.Core.Models;
using LiloDash.Domain.Enums.EntityAudits;

namespace LiloDash.Domain.Model.EntityAudits
{
    /// <summary>
    /// Entity Audit
    /// </summary>
    public class EntityAudit : Entity
    {
        
        /// <summary>
        /// Id of current transaction
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Entity changed
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Primary Key of the changed property
        /// </summary>
        public string KeyValuesJson { get; set; }

        /// <summary>
        /// User who make the changes
        /// </summary>
        public string LoggedUserJson { get; set; }

        /// <summary>
        /// Old values in JSON format
        /// </summary>
        public string OldValuesJson { get; set; }

        /// <summary>
        /// New values in JSON format
        /// </summary>
        public string NewValuesJson { get; set; }

        public EntityAuditOperationType Operation { get; set; }

        public IDictionary<string, object> KeyValues
        {
            get { return Deserialize(KeyValuesJson); }
            set { KeyValuesJson = JsonConvert.SerializeObject(value); }
        }

        public IDictionary<string, object> OldValues
        {
            get { return Deserialize(OldValuesJson); }
            set { OldValuesJson = JsonConvert.SerializeObject(value); }
        }

        public IDictionary<string, object> NewValues
        {
            get { return Deserialize(NewValuesJson); }
            set { NewValuesJson = JsonConvert.SerializeObject(value); }
        }

        public EntityAuditUser User
        {
            get
            {
                return string.IsNullOrWhiteSpace(LoggedUserJson)
                    ? null
                    : JsonConvert.DeserializeObject<EntityAuditUser>(LoggedUserJson);
            }
            set { LoggedUserJson = JsonConvert.SerializeObject(value); }
        }

        public void SetNewValues(string key, object value)
        {
            var newValues = NewValues;
            newValues[key] = value;
            NewValues = newValues;            
        }

        public void SetOldValues(string key, object value)
        {
            var oldValues = OldValues;
            oldValues[key] = value;
            OldValues = oldValues;
        }

        public void SetKeyValues(string key, object value)
        {
            var keyValues = KeyValues;
            keyValues[key] = value;
            KeyValues =keyValues;
        }

        private IDictionary<string, object> Deserialize(string serializedString)
            => string.IsNullOrWhiteSpace(serializedString)
                    ? new Dictionary<string, object>()
                    : JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedString);
    }
}
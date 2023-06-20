
# Azure Service Bus Geo-disastor Recovery

Resilience against data processing outages is important for enterprises and industry regulations. An outage in Azure Service Bus refers to a temporary unavailability of the service, affecting specific components or even the entire datacenter. It is typically resolved, with no loss of messages or data. On the other hand, a disaster is a longer-term or permanent loss of a Service Bus cluster, Azure region, or datacenter due to events like fire or flooding. Disasters may result in message or data loss, but data recovery is possible once the affected datacenter is restored. The Geo-disaster recovery feature of Azure Service Bus provides a solution for recovering from such disasters.

Azure Service Bus spreads the risk of failures across multiple clusters and implements transparent failure detection and failover mechanisms.

Premium tier namespaces further spread outage risk across multiple facilities and have enough capacity reserves to handle catastrophic datacenter loss.

Service Bus Geo-disaster recovery feature helps recover from a disaster by abandoning a failed Azure region without changing application configurations.

The feature continuously replicates namespace configuration from a primary to a secondary namespace and allows for a once-only failover move.

The failover move repoints the alias name to the secondary namespace and is nearly instantaneous.


## Design Considerations

 - The feature ensures seamless operations without configuration changes, but it doesn't replicate message data in queues or topic subscriptions. Replicating message data would require replicating every state change in the broker, leading to excessive traffic. High-throughput queues may replicate messages unnecessarily, causing wasteful traffic. Latency-induced throttling effects may hinder sustainable replication traffic for high-latency replication routes.
 
 - The following configurations aren't replicated:
    - RBAC assignments for Service Bus entities in the primary namespace don't replicate to the secondary namespace. Manual creation of role assignments is required in the secondary namespace for securing access to those entities.
    - Virtual network configurations
    - Private endpoint connections
    - All networks access enabled
    - Trusted service access enabled
    - Public network access
    - Default network action
    - Identities and encryption settings (customer-managed key encryption or bring your own key (BYOK) encryption)
    - Enable auto scale
    - Disable local authentication

## Basic Concepts & Terms

## References

 - [MS Learn - Azure Service Bus Geo DR](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-geo-drs)
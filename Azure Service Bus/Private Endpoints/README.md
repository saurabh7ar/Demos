# Access Azure Service Bus via Private EndPoints

Azure Private Link Service enables you to access Azure services and Azure hosted customer-owned/partner services over a **private endpoint** in your virtual network.
A private endpoint is a network interface that connects you privately and securely to a service powered by Azure Private Link.
Traffic between your virtual network and the service traverses over the **Microsoft backbone network**, eliminating exposure from the public Internet.
Azure Private Link provides the following benefits:
    1. Privately access services on the Azure platform
    2. Access services running in Azure from on-premises over ExpressRoute private peering, VPN tunnels, and peered virtual networks using private endpoints.
    3. Protect against data leakage

Keep in mind these important factors while implementing private endpoints for Azure Service Bus:
    Service Bus can restrict integration with other Azure services, but exceptions can be made for trusted services. For a list of trusted services, refer this link - https://learn.microsoft.com/en-us/azure/service-bus-messaging/private-link-service#trusted-microsoft-services
    The following Microsoft services are required to be on a virtual network:
        Azure App Service
        Azure Functions
    To control access to a namespace, **Specify at least one IP rule or virtual network rule** to restrict traffic to specified addresses or subnets. Without such rules, the namespace is accessible via the public internet using the access key.

**Add a private endpoint using Azure portal**

Prerequisites
To enable Azure Private Link integration for a Service Bus namespace, you require the following entities or permissions:
    A Service Bus namespace.
    An Azure virtual network with a subnet (default subnet can be used).
    Owner or contributor permissions for both the Service Bus namespace and the virtual network.
    The **private endpoint and virtual network must be in the same region**.

![image](https://github.com/saurabh7ar/Demos/assets/132929888/65b4917f-8fc8-495e-bc3e-68be26b7403e)
![image](https://github.com/saurabh7ar/Demos/assets/132929888/9535a16f-4211-4ee5-b2bb-89d16dbebead)
![image](https://github.com/saurabh7ar/Demos/assets/132929888/d0a0eb73-a712-48fa-b674-e305f97be173)
![image](https://github.com/saurabh7ar/Demos/assets/132929888/b2d3148b-a1da-4726-a350-e651d349636a)
![image](https://github.com/saurabh7ar/Demos/assets/132929888/f29e63e4-5c52-4e5a-aedd-67d14659a8c2)
![image](https://github.com/saurabh7ar/Demos/assets/132929888/1e7dbcc6-465f-47da-9064-0729e4513e1b)



References:
    https://learn.microsoft.com/en-us/azure/private-link/private-link-overview
    https://learn.microsoft.com/en-us/azure/service-bus-messaging/private-link-service

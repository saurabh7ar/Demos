
# API Management Landing Zone Accelerator

The Azure API Management landing zone accelerator offers an architectural approach and reference implementation for scalable API Management infrastructure. It aligns with the Cloud Adoption Framework's Azure landing zones and enterprise-scale design principles.

- It can be used a design guide for greenfield implementation and as an assessment guide for brownfield.
- The IaaC template can be customized to match naming conventions, utilize existing resources, and integrate with various backends.

## Guidelines

The article offer guidance on building your APIM landing zone using Azure landing zone design areas.

- IAM
  - Identity and access management covers multiple aspects including access to manage the API Management instance, API developer access, and client access to APIs.
  - Use [built-in-roles](https://learn.microsoft.com/en-us/azure/api-management/api-management-role-based-access-control#built-in-roles) to manage responsibilities across teams to manage APIM instance.
  - Use custom roles based on API Management [RBAC operations](https://learn.microsoft.com/en-us/azure/role-based-access-control/resource-provider-operations#microsoftapimanagement) to set fine-grained access.
  - [Azure AD B2C](https://learn.microsoft.com/en-us/azure/api-management/api-management-howto-aad-b2c) is a cloud identity management solution for consumer-facing web and mobile applications. You can use it to manage access to your API Management developer portal.
- Network topology and connectivity
  - Networking is vital for connectivity in a APIM landing zone, linking Azure services, users, and external APIs.
  - It is crititcal to have answer to these questions, before designing networking components for your APIM instance:
     - APIS are accessible externally or internally?
     - Does Network set up requires cross-region connectivity? Based on this you can decide which gateway ([Application Gateway](https://learn.microsoft.com/en-us/azure/application-gateway/overview)/ [Azure Front Door](https://learn.microsoft.com/en-us/azure/frontdoor/front-door-overview)) needs to be deployed? 
     - Does APIM needs to be accessed through a private endpoint?
     - #### Network Design Recommendations
        - Use [Application Gateway](https://learn.microsoft.com/en-us/azure/api-management/api-management-howto-integrate-internal-vnet-appgateway) for exposing APIs externally, when APIM is inatalled in internal mode in a VNet.
       - For multi-region deployment use Azure Front Door.
- Security
   - Deals with securing Frontend APIs, Backends & developer portal.
   - References
      - [Authn & Authz](https://learn.microsoft.com/en-us/azure/api-management/authentication-authorization-overview)
- Management
- Governance
- Platform automation and DevOps

## Implementation

 - [IaaC Template](https://github.com/Azure/apim-landing-zone-accelerator)

## References

 - [Azure APIM Landing zone accelerator](https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/scenarios/app-platform/api-management/landing-zone-accelerator)
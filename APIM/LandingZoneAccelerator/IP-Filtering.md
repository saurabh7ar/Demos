
# APIM IP-Filtering

## Introduction
In the context of Azure API Management (APIM), IP filtering is an important security measure that helps protect APIs from unauthorized access. By implementing IP filtering, you can restrict access to your APIs based on the source IP addresses or IP ranges. This architectural document provides guidance on implementing IP filtering in Azure APIM while following the defense in depth principle.

## Defense in Depth

Defense in depth is a security strategy that involves implementing multiple layers of defense to mitigate risks and protect against attacks. By layering security defenses, the chances of a successful attack are significantly reduced. When designing and implementing IP filtering in Azure APIM, it is important to consider defense in depth principles to ensure a robust security posture.

## Azure Web Application Firewall (WAF)
To enhance the security of Azure APIM and protect against common web application exploits and vulnerabilities, it is recommended to deploy a Web Application Firewall (WAF) in front of APIM. Azure WAF provides inspection of HTTP requests and helps prevent malicious attacks at the web layer, such as SQL injection and cross-site scripting.
Azure Firewall and Application Gateway are two services that can be used to protect web applications, including APIM, from malicious attacks. Azure Firewall is a network firewall that filters inbound and outbound traffic, while Application Gateway is a load balancer that provides web application firewall (WAF) features. You can use these services in parallel or in sequence, depending on your design and security needs.

  ### WAF Policy & Rules
  To enable a Web Application Firewall on Azure Application Gateway for APIM, you need to create a WAF policy. The WAF policy contains managed rules, custom rules, exclusions, and other customizations specific to your application's protection requirements.

  ### Managed Rules Sets
  Managed rule sets are pre-configured sets of rules provided by Azure to protect against common web application vulnerabilities. When both managed and custom rules are present in a WAF policy, custom rules are processed before the managed rule sets. A rule is comprised of match condition, a priority, and an action (ALLOW, BLOCK, or LOG). You can create a fully customized policy by combining managed and custom rules.

  ### Custom Rules Sets
  Custom rules allow you to create your own rules that are evaluated for each request passing through the WAF. These rules take priority over the rules in the managed rule sets. If a custom rule is triggered and an allow or block action is taken, no further custom or managed rules are evaluated.

  Custom rules can be enabled or disabled on demand and support compounding logic to create advanced rules. For example, you can create a rule that specifies ((Condition 1 and Condition 2) or Condition 3), meaning that if Condition 1 and Condition 2 are met, or if Condition 3 is met, the specified action should be taken by the WAF.

  ### Fields for Custom Rules
  - Name (optional): Specifies an optional name for the rule.
  - Enable Rule (optional): Allows enabling or disabling the custom rule.
  - Priority (required): Specifies the priority order of rules. A lower integer value denotes a higher priority, and rules with lower priorities are evaluated first.
  - Rule Type (required): Specifies the type of rule, such as IPMatch or other custom conditions.
  - Match variable (required): Defines the match condition for the rule, such as IP address ranges.
  - Action: Specifies the action to be taken when the rule is triggered (ALLOW, BLOCK, or LOG).

## Implementation Guidelines

When implementing IP filtering in Azure APIM using WAF, consider the following guidelines:
  - Deploy Azure Application Gateway with a Web Application Firewall (WAF) in front of APIM to provide protection against common web application exploits and vulnerabilities.
  - Create a WAF policy that includes managed rule sets and custom rules.
  - Configure custom rules with appropriate match conditions, priorities, and actions based on your specific security requirements.
  - Ensure that custom rules are evaluated before the managed rule sets.
  - Regularly review and update the WAF policy to incorporate any necessary changes or new security threats.
  - Monitor and analyze WAF logs and metrics to identify potential attacks or security incidents.
  - Follow the principle of least privilege when configuring IP filtering rules, allowing only necessary IP addresses or IP ranges to access your APIM services.
  - Consider using Azure Firewall and Application Gateway in parallel or in sequence to further enhance your security defenses, depending on your design and security needs.

![image](https://github.com/saurabh7ar/Demos/assets/132929888/2f67b637-9bc6-4146-88b1-df5b582bc102)


By following these guidelines, you can implement a robust IP filtering solution for Azure APIM while adhering to the defense in depth principle.

Refer - [IaaC](https://github.com/Azure/azure-quickstart-templates/tree/master/demos/ag-docs-qs)

## Conclusion
IP filtering is an essential security measure to protect Azure APIM services from unauthorized access. By leveraging Azure Web Application Firewall (WAF) capabilities, along with custom rules and managed rule sets, you can implement a defense in depth strategy for securing your APIM services. This architectural document has provided an overview of IP filtering in Azure APIM and outlined the steps to configure WAF policies and rules. By implementing these best practices, you can enhance the security of your Azure APIM deployments.

## References

 - [Azure Application Gateway](https://learn.microsoft.com/en-us/azure/web-application-firewall/ag/ag-overview)
 - [WAF DRS and CRS rule groups and rules](https://learn.microsoft.com/en-us/azure/web-application-firewall/ag/application-gateway-crs-rulegroups-rules?tabs=drs21)
 - [WAF Custom Rules](https://learn.microsoft.com/en-us/azure/web-application-firewall/ag/custom-waf-rules-overview)
 - [Service Limits](https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/azure-subscription-service-limits#application-gateway-limits)

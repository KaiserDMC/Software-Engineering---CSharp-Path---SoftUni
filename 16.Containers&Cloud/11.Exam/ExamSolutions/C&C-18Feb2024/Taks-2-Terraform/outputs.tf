output "webapp_url" {
  value = azurerm_linux_web_app.azureLinuxWebApp.default_hostname
}

output "webapp_ips" {
  value = azurerm_linux_web_app.azureLinuxWebApp.outbound_ip_addresses
}

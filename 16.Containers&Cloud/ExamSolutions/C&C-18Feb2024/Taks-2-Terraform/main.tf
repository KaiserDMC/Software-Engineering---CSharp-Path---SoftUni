terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.91.0"
    }
  }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "resGroup" {
  name     = var.resource_group_name
  location = var.resource_group_location
}

resource "azurerm_service_plan" "azureServiceP" {
  name                = var.app_service_plan_name
  resource_group_name = azurerm_resource_group.resGroup.name
  location            = azurerm_resource_group.resGroup.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "azureLinuxWebApp" {
  name                = var.app_service_name
  resource_group_name = azurerm_resource_group.resGroup.name
  location            = azurerm_service_plan.azureServiceP.location
  service_plan_id     = azurerm_service_plan.azureServiceP.id
  connection_string {
    name  = "DefaultConnection"
    type  = "SQLAzure"
    value = "Data Source=tcp:${azurerm_mssql_server.sqlServer.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.sqlDatabase.name};User ID=${azurerm_mssql_server.sqlServer.administrator_login};Password=${azurerm_mssql_server.sqlServer.administrator_login_password};Trusted_Connection=False; MultipleActiveResultSets=True;"
  }
  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
    always_on = false
  }
}

resource "azurerm_mssql_server" "sqlServer" {
  name                         = var.sql_server_name
  resource_group_name          = azurerm_resource_group.resGroup.name
  location                     = azurerm_resource_group.resGroup.location
  version                      = "12.0"
  administrator_login          = var.sql_admin_login
  administrator_login_password = var.sql_admin_password
}

resource "azurerm_mssql_database" "sqlDatabase" {
  name           = var.sql_database_name
  server_id      = azurerm_mssql_server.sqlServer.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  max_size_gb    = 2
  sku_name       = "S0"
  zone_redundant = false
}

resource "azurerm_mssql_firewall_rule" "firewall" {
  name             = var.firewall_rule_name
  server_id        = azurerm_mssql_server.sqlServer.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}

resource "azurerm_app_service_source_control" "sourcecontrol" {
  app_id                 = azurerm_linux_web_app.azureLinuxWebApp.id
  repo_url               = var.repo_URL
  branch                 = "main"
  use_manual_integration = true
}

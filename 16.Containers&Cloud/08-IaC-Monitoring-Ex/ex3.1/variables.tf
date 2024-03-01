variable "resource_group_name" {
  type        = string
  description = "Azure Resource Group"
}

variable "resource_group_location" {
  type        = string
  description = "Azure Resource Group Location"
}

variable "app_service_plan_name" {
  type        = string
  description = "Azure Service Plan Name"
}

variable "app_service_name" {
  type        = string
  description = "Azure App Name"
}

variable "sql_server_name" {
  type        = string
  description = "Azure MSSQL Server Name"
}

variable "sql_database_name" {
  type        = string
  description = "Azure MSSQL DB Name"
}

variable "sql_admin_login" {
  type        = string
  description = "Azure MSSQL DB Admin Login"
}

variable "sql_admin_password" {
  type        = string
  description = "Azure MSSQL DB Admin Password"
}

variable "firewall_rule_name" {
  type        = string
  description = "Azure MSSQL Firewall Rule name"
}

variable "repo_URL" {
  type        = string
  description = "GitHub Repository"
}
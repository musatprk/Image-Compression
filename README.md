# Image Compression and Azure Blob Storage Integration Service

## Description

This service compresses large images to the desired quality and uploads them to Azure Blob Storage. The project integrates with Azure Key Vault to securely manage credentials and dynamically uploads compressed images to the blob storage defined in the Key Vault.

### Features:
- **Image Compression:** Compress high-resolution images to a specified quality.
- **Azure Key Vault Integration:** Securely manage Azure Blob Storage credentials.
- **Azure Blob Storage Integration:** Dynamically upload compressed images to predefined blob storage containers.

---

## Türkçe Açıklama

Bu servis, büyük boyutlu resimleri istediğiniz kalitede sıkıştırıp Azure Blob Storage'a yükler. Proje, Azure Key Vault ile entegredir ve kimlik bilgilerini güvenli bir şekilde yönetir, ardından sıkıştırılmış resimleri dinamik olarak Key Vault'ta tanımlı blob storage'lara yükler.

### Özellikler:
- **Resim Sıkıştırma:** Yüksek çözünürlüklü resimleri istenilen kalitede sıkıştırır.
- **Azure Key Vault Entegrasyonu:** Azure Blob Storage kimlik bilgilerini güvenli bir şekilde yönetir.
- **Azure Blob Storage Entegrasyonu:** Sıkıştırılmış resimleri önceden tanımlanmış blob storage kaplarına dinamik olarak yükler.

---

## Requirements / Gereksinimler

- **.NET Framework**: The project is built using the .NET framework.
- **Azure Key Vault**: For securely managing and retrieving secrets (like Blob Storage connection strings).
- **Azure Blob Storage**: For storing compressed images in blob containers.

---

## Setup / Kurulum

1. **Azure Key Vault Setup:**
   - Create a Key Vault in the Azure portal.
   - Store your Blob Storage connection string as a secret.

2. **Azure Blob Storage Setup:**
   - Create a Blob Storage account.
   - Define containers for storing compressed images.

3. **Configuration:**
   - Set up environment variables for your Key Vault and Blob Storage.
   - Adjust image compression quality based on your needs.

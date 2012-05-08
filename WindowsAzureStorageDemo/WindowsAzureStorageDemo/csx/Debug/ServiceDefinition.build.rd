<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzureStorageDemo" generation="1" functional="0" release="0" Id="f1ded336-dc21-4c1d-85b5-0fcd829325b5" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzureStorageDemoGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="StorageSite:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/LB:StorageSite:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="StorageSite:Blobs" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/MapStorageSite:Blobs" />
          </maps>
        </aCS>
        <aCS name="StorageSite:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/MapStorageSite:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="StorageSite:TaskList" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/MapStorageSite:TaskList" />
          </maps>
        </aCS>
        <aCS name="StorageSiteInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/MapStorageSiteInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:StorageSite:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSite/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapStorageSite:Blobs" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSite/Blobs" />
          </setting>
        </map>
        <map name="MapStorageSite:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSite/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapStorageSite:TaskList" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSite/TaskList" />
          </setting>
        </map>
        <map name="MapStorageSiteInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSiteInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="StorageSite" generation="1" functional="0" release="0" software="C:\src\DEMO-Presentations\WindowsAzureStorageDemo\WindowsAzureStorageDemo\csx\Debug\roles\StorageSite" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Blobs" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="TaskList" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;StorageSite&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;StorageSite&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSiteInstances" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSiteFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="StorageSiteFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="StorageSiteInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="5ca17d38-8b89-453a-ba04-484215f62414" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzureStorageDemoContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="f83c84a0-e02e-4d72-90ad-3744536bb6d9" ref="Microsoft.RedDog.Contract\Interface\StorageSite:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/WindowsAzureStorageDemo/WindowsAzureStorageDemoGroup/StorageSite:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>
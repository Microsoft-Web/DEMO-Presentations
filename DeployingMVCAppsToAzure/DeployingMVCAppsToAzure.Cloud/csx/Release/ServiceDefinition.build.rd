<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="DeployingMVCAppsToAzure.Cloud" generation="1" functional="0" release="0" Id="077a501f-c63b-4f38-8d8d-904a453020d1" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="DeployingMVCAppsToAzure.CloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="DeployingMVCAppsToAzure:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/LB:DeployingMVCAppsToAzure:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="DeployingMVCAppsToAzure:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/MapDeployingMVCAppsToAzure:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="DeployingMVCAppsToAzure:MyAzureRoleAppSetting" defaultValue="">
          <maps>
            <mapMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/MapDeployingMVCAppsToAzure:MyAzureRoleAppSetting" />
          </maps>
        </aCS>
        <aCS name="DeployingMVCAppsToAzureInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/MapDeployingMVCAppsToAzureInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:DeployingMVCAppsToAzure:Endpoint1">
          <toPorts>
            <inPortMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/DeployingMVCAppsToAzure/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapDeployingMVCAppsToAzure:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/DeployingMVCAppsToAzure/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapDeployingMVCAppsToAzure:MyAzureRoleAppSetting" kind="Identity">
          <setting>
            <aCSMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/DeployingMVCAppsToAzure/MyAzureRoleAppSetting" />
          </setting>
        </map>
        <map name="MapDeployingMVCAppsToAzureInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/DeployingMVCAppsToAzureInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="DeployingMVCAppsToAzure" generation="1" functional="0" release="0" software="C:\src\DEMO-Presentations\DeployingMVCAppsToAzure\DeployingMVCAppsToAzure.Cloud\csx\Release\roles\DeployingMVCAppsToAzure" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="MyAzureRoleAppSetting" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;DeployingMVCAppsToAzure&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;DeployingMVCAppsToAzure&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/DeployingMVCAppsToAzureInstances" />
            <sCSPolicyFaultDomainMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/DeployingMVCAppsToAzureFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="DeployingMVCAppsToAzureFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="DeployingMVCAppsToAzureInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="04638654-76d3-4d59-b511-1a0b9f065429" ref="Microsoft.RedDog.Contract\ServiceContract\DeployingMVCAppsToAzure.CloudContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="2d51a333-d5a0-4feb-aa57-0c0cb3498f72" ref="Microsoft.RedDog.Contract\Interface\DeployingMVCAppsToAzure:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/DeployingMVCAppsToAzure.Cloud/DeployingMVCAppsToAzure.CloudGroup/DeployingMVCAppsToAzure:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>
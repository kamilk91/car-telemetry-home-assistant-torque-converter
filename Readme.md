
# Converter for Torque (Vehicle / Car telemetry) 

If you created car telemetry with this instruction https://childof69.co.uk/ha-car-telemetry/ you propably need to add a lot of work to make everything works. 




# instruction

- Download Visual Studio Community 2022
- Open project in that
- In `sample.txt` file replace `sensor.bmw_torque` with your car.
- Go to your homeassistant.url/developer-tools/template and use below script (replace bmw with your car name) [thanks to https://community.home-assistant.io/t/show-all-attributes-of-an-entity-like-they-were-individual-entities/385299 Ildar_Gabdullin i took your code.]

```
    {% set SENSOR = 'sensor.bmw_torque' -%}
    {%- for attr in states[SENSOR].attributes -%}
      {{
        {
          'type': 'attribute',
          'entity': SENSOR,
          'attribute': attr,
          'name': attr
        }
      }},
    {%- endfor %}

```

- Paste generated json into `input.txt` in my program
- Run program
- Find `output.yaml` in build folder (for example `C:\path\to\program\Debug\output.yaml`)
- Paste everything from output to your configuration.yaml (under your car instance) like this:

```
sensor:
  - platform: mqtt
    name: "BMW Torque"
    state_topic: "devices/bmw/torque"
    value_template: "{{ state_attr('sensor.bmw_torque', 'GPS Time') }}"
    json_attributes_topic: "devices/bmw/torque"
    unique_id: "sensor.bmw"


  - platform: template
    sensors: 
      bmw_torque_gpstime:
        friendly_name: "GPS Time"
        unit_of_measurement: ''
        value_template: "{{ state_attr('sensor.bmw_torque','GPS Time') }}"

  - platform: template
    sensors: 
      bmw_torque_devicetime:
        friendly_name: "Device Time"
        unit_of_measurement: ''
        value_template: "{{ state_attr('sensor.bmw_torque','Device Time') }}"
  - platform: template

```

voila!
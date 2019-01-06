FILENAME = "pallette2.pal"

hexes = File.read(FILENAME).split("\n")

rgbs = []
hexes.each do |hex|
  hex = hex.split
  next if hex.size != 3
  rgbs << [hex[0].to_i, hex[1].to_i, hex[2].to_i]
end

boilerplate =
"""%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!114 &1
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 1
  m_Script: {fileID: 12323, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: 
  m_EditorClassIdentifier: 
  m_Presets:
"""

f = File.open("#{FILENAME.split(".")[0]}.colors","w")
f.write(boilerplate)

rgbs.each do |col|
f.write(
"""  - m_Name: 
    m_Color: {r: #{col[0].to_f/256}, g: #{col[1].to_f/256}, b: #{col[2].to_f/256}, a: 1}
"""
)
end
f.close
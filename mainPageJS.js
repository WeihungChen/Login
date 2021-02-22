function SideBarStateChange()
{
	if(document.getElementById("sidebar1").style.width == "0px")
	{
		document.getElementById("sidebar1").style.width = "100px";
		document.getElementById("main").style.marginLeft = "100px";
	}
	else
	{
		document.getElementById("sidebar1").style.width = "0px";
		document.getElementById("main").style.marginLeft = "0px";
	}
}
# Switcher: Automatically switch widgets and dashboards

The Switcher widget is *not a widget* per se, but it adds some functionality on existing ones: When adding widgets to a dashboard, one gets easily out of screenspace because of not many widgets can be added in same screen/dashboard. Instead of putting them into separate dashboards, **Switcher can switch widgets in same region periodically**:

![Example of using Switcher with three Twitter widgets](https://cloud.githubusercontent.com/assets/781002/3454320/ec49d538-01cf-11e4-99a7-019e7b140db1.gif)

While the requirement for multiple dashboard is decreased with multiple widgets, **Switcher is capable of switching the dashboards** too.

## Usage: Switch widgets

1. Add multiple widgets within one grid list element
2. (Optional) Set interval in milliseconds how often the widgets are changed by using ```data-switcher-interval``` attribute. Defaults to 5 seconds (5000).

```html
<li data-switcher-interval="3000" data-row="1" data-col="1" data-sizex="1" data-sizey="1">
    <div data-id="kue-information" data-view="KueStatus"></div>
    <div data-id="pingdom-uptime-dashboard" data-view="PingdomUptime"></div>
    <div data-id="nagios-detailed-list" data-view="NagiosList"></div>
</li>
````

## Usage: Switch dashboards

Switcher can switch dashboards too, by reloading the page to another dashboard.

1. Set names (as they appear in URL) of the dashboards in layout.erb into container element. Separate dashboard names with space or comma.
2. (Optional) Set interval in milliseconds how often the dashboard is changed by using ```data-switcher-interval``` attribute. Defaults to 60 seconds (60000).

```erb
<div id="container" data-switcher-interval="10000" data-switcher-dashboards="dashboard1 dashboard2">
  <%= yield %>
</div>
```

> Switcher widget is contributed by Juha Mustonen / SC5
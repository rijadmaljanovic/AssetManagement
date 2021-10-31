<template>
<div class="stylemap">
    <l-map :zoom="zoom" :center="latLng(latitude, longitude)">
        <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
        <l-marker :lat-lng="latLng(latitude, longitude)"></l-marker>
    </l-map>
</div>
   
</template>

<script>
import L from 'leaflet';
import { LMap, LTileLayer, LMarker } from 'vue2-leaflet';

export default {
  name: 'Map',
  props: ["latitude", "longitude"],
  components: {
    LMap,
    LTileLayer,
    LMarker,
  },
  data(){
      return{
        url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
        attribution:
            '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
        zoom: 12,
        //center: L.latLng(33.74651129476743, -84.37117526458108),
        //markerLatLng: L.latLng(33.74651129476743, -84.37117526458108) 
      }
  },
  methods:{
    latLng(lat, lng){
      return L.latLng(lat, lng);
    }
  }
};

</script>

<style>
.stylemap{
    height: 400px;
    width: 500px;
}



</style>
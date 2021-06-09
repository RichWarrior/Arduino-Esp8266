<script>
import VueChartJs from 'vue-chartjs'
export default {
  extends: VueChartJs.Bar,
  props: {
    labels: {},
    datasets: {},
  },
  methods: {
    ardRender() {
        console.log('chart render')
      this.renderChart(
        {
          labels: this.labels,
          datasets: this.datasets,
        },
        { responsive: true, maintainAspectRatio: false }
      );
    },
  },
  mounted() {
    this.ardRender();
  },
};
</script>
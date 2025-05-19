import React, { useEffect, useState } from 'react';
import {
  View,
  Text,
  StyleSheet,
  ImageBackground,
  FlatList,
  TouchableOpacity,
  Platform,
} from 'react-native';
import DateTimePicker from '@react-native-community/datetimepicker';
import PageContainer from '../components/PageContainer.js';

export default function HistoricoAgendamentos({ route }) {
  const [agendamentos, setAgendamentos] = useState([]);
  const [dataSelecionada, setDataSelecionada] = useState(new Date());
  const [mostrarDatePicker, setMostrarDatePicker] = useState(false);

  const barbeiroId = route?.params?.barbeiroId;
  const clienteId = route?.params?.clienteId;

  useEffect(() => {
    let url = 'https://sua-api.com/agendamentos/historico?';
    if (barbeiroId) url += `barbeiroId=${barbeiroId}&`;
    if (clienteId) url += `clienteId=${clienteId}&`;
    url += `data=${dataSelecionada.toISOString().split('T')[0]}`;

    fetch(url)
      .then((res) => res.json())
      .then((data) => setAgendamentos(data))
      .catch((err) => {
        console.error(err);
        setAgendamentos([]);
      });
  }, [dataSelecionada]);

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
    >
      <PageContainer>
        <Text style={styles.title}>Histórico de Agendamentos</Text>

        <TouchableOpacity onPress={() => setMostrarDatePicker(true)}>
          <Text style={styles.dateLabel}>Selecionar data:</Text>
          <Text style={styles.dateValue}>{dataSelecionada.toLocaleDateString()}</Text>
        </TouchableOpacity>

        {mostrarDatePicker && (
          <DateTimePicker
            value={dataSelecionada}
            mode="date"
            display={Platform.OS === 'ios' ? 'spinner' : 'default'}
            onChange={(event, selectedDate) => {
              setMostrarDatePicker(false);
              if (selectedDate) setDataSelecionada(selectedDate);
            }}
          />
        )}

        {agendamentos.length === 0 ? (
          <Text style={styles.emptyText}>Nenhum agendamento encontrado.</Text>
        ) : (
          <FlatList
            data={agendamentos}
            keyExtractor={(item) => item.id.toString()}
            renderItem={({ item, index }) => (
              <View style={styles.card}>
                <Text style={styles.numero}>{index + 1}.</Text>
                <View>
                  <Text style={styles.servico}>{item.servico}</Text>
                  {item.barbeiro && (
                    <Text style={styles.barbeiro}>Barbeiro: {item.barbeiro}</Text>
                  )}
                  {item.cliente && (
                    <Text style={styles.cliente}>Cliente: {item.cliente}</Text>
                  )}
                  <Text style={styles.data}>{item.data}</Text>
                </View>
              </View>
            )}
          />
        )}
      </PageContainer>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  title: {
    color: '#fff',
    fontSize: 22,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 20,
    marginTop: 170,
  },
  dateLabel: {
    color: '#fff',
    fontWeight: '600',
    marginBottom: 5,
  },
  dateValue: {
    color: '#fff',
    marginBottom: 20,
  },
  emptyText: {
    color: '#fff',
    textAlign: 'center',
    fontSize: 16,
  },
  card: {
    backgroundColor: 'rgba(54,54,54,0.9)',
    borderRadius: 15,
    padding: 15,
    marginBottom: 15,
    flexDirection: 'row',
    gap: 10,
    alignItems: 'center',
  },
  numero: {
    color: '#fff',
    fontWeight: 'bold',
    fontSize: 16,
  },
  servico: {
    color: '#fff',
    fontSize: 15,
    fontWeight: '600',
  },
  barbeiro: {
    color: '#ddd',
    fontSize: 13,
    marginBottom: 2,
  },
  cliente: {
    color: '#bbb',
    fontSize: 13,
    marginBottom: 2,
  },
  data: {
    color: '#ccc',
    fontSize: 13,
  },
});